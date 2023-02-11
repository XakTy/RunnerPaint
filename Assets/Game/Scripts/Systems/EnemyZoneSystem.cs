using Game.Scripts.Components;
using Leopotam.Ecs;

namespace Zlodey
{
	public sealed class EnemyZoneSystem : IEcsRunSystem
	{
		private readonly EcsFilter<EnemyTag, TransformRef, OnTriggerEnterEvent> _filter;
		public void Run()
		{
			foreach (var i in _filter)
			{
				var entityTrigger = _filter.Get3(i);
				if (entityTrigger.EnterEntity.Has<CharacterTag>())
				{
					var transform = _filter.Get2(i).value;
					entityTrigger.EnterEntity.Get<DiedEventZone>().value = transform;
				}
			}
		}
	}
}