using System;
using Game.Scripts.Components;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace Zlodey
{
	public sealed class EnemyZoneSystem : IEcsRunSystem
	{
		private readonly EcsFilter<OnTriggerEnterEvent> _filter;
		public void Run()
		{
			foreach (var i in _filter)
			{
				ref var entityTrigger = ref _filter.Get1(i);
				var entity = _filter.GetEntity(i);

				if (entityTrigger.EntityA.Has<CharacterTag>() && entityTrigger.EntityB.Has<EnemyTag>())
				{
					entityTrigger.EntityA.Get<DiedEventZone>();

					entity.Destroy();
					continue;
				}

				if (entityTrigger.EntityB.Has<CharacterTag>() && entityTrigger.EntityA.Has<EnemyTag>())
				{
					entityTrigger.EntityB.Get<DiedEventZone>();

					entity.Destroy();
					continue;
				}

			}
		}
	}
}