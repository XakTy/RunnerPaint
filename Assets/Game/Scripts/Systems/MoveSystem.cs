using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Zlodey
{
	public static class LeoEcsExtenshion
	{
		public static bool Exist(this EcsFilter filter, EcsEntity entity)
		{
			var map = filter.GetInternalEntitiesMap();
			var entityId = entity.GetInternalId();

			if (map.ContainsKey(entityId))
			{
				return true;
			}

			return false;
		}
		public static bool Exist(this EcsFilter filter, EcsEntity entity, out int i)
		{
			var map = filter.GetInternalEntitiesMap();
			var entityId = entity.GetInternalId();

			if (map.TryGetValue(entityId, out int idx))
			{
				i = idx;
				return true;
			}

			i= -1;
			return false;
		}
	}

	public sealed class MoveSystem : IEcsRunSystem
	{
		private readonly EcsFilter<CharacterTag, TransformRef, CharacterControllerRef, TargetPosition>.Exclude<Freeze> _filterMoverNewPosition;
		private readonly RuntimeData _runtimeData;
		private readonly StaticData _staticData;

		public void Run()
		{
			if (_runtimeData.GameState != GameState.Playing) return;

			foreach (var i in _filterMoverNewPosition)
			{
				var transform = _filterMoverNewPosition.Get2(i).value;
				var character = _filterMoverNewPosition.Get3(i).value;
				var position = _filterMoverNewPosition.Get4(i).value;

				var dir = (position - transform.localPosition);

				transform.transform.localPosition = Vector3.MoveTowards(transform.localPosition, position, _staticData.SpeedEditPosition * _runtimeData.deltaTime);

				//character.Move(dir.normalized * _staticData.SpeedEditPosition * _runtimeData.deltaTime);

				if (dir.sqrMagnitude < 0.1f)
				{
					var entity = _filterMoverNewPosition.GetEntity(i);
					entity.Del<TargetPosition>();
				}
			}
		}
	}
}