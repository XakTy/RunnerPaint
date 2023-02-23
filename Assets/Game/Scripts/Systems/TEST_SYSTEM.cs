using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Zlodey
{
	public struct MessageEvent
	{
		public string value;
		public EcsEntity EntityA;
		public EcsEntity EntityB;
	}
	public class HelpSystemEvent : IEcsRunSystem
	{
		private EcsFilter<CharacterTag> _filterCharacter;
		private readonly EcsFilter<MessageEvent> _filter;

		public void Logic(EcsEntity entityEventEntityA, EcsEntity entityEventEntityB, MessageEvent newEvent)
		{
			Debug.Log(newEvent.value);
		}

		public void Run()
		{
			if (_filter.IsEmpty()) return;

			foreach (var i in _filter)
			{
				ref var entityEvent = ref _filter.Get1(i);
				var entity = _filter.GetEntity(i);

				if (_filterCharacter.Exist(entityEvent.EntityA, out var indexA) && _filterCharacter.Exist(entityEvent.EntityB, out var indexB))
				{
					Logic(entityEvent.EntityA, entityEvent.EntityB, entityEvent);
					entity.Destroy();
				}
			}
		}
	}
}