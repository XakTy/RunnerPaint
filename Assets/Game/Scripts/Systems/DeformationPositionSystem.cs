using System.Collections.Generic;
using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Zlodey
{
	public sealed class DeformationPositionSystem : IEcsRunSystem
	{
		private readonly EcsFilter<EventDeformationPosition> _filter;
		private readonly EcsFilter<CharacterTag, TransformRef> _filterMover;
		private readonly EcsFilter<CharacterTag, TransformRef>.Exclude<NewPositionEvent> _filterMoverChecker;
		private readonly StaticData _staticData;

		public void Run()
		{
			foreach (var i in _filter)
			{
				var points = _filter.Get1(i).value;
				bool noPlace = true;
				int indexPos = 0;

				for (int j = 0; j < points.Count; j++)
				{
					if (j == _filterMover.GetEntitiesCount())
					{
						noPlace = false;
						indexPos = j;
						break;
					}

					var entityMover = _filterMover.GetEntity(j);
					entityMover.Get<NewPositionEvent>().value = CalcalutePosition(points[j]);
				}

				if (noPlace)
				{
					GetNewPosition(points[indexPos]);
				}



				var entity = _filter.GetEntity(i);
				entity.Destroy();

			}
		}

		private Vector3 CalcalutePosition(Vector2 point)
		{
			var pos = new Vector3(point.x, 0f, point.y);
			pos.x = Mathf.Clamp(pos.x, _staticData.RangeX.x, _staticData.RangeX.y);
			pos.z = Mathf.Clamp(pos.z, _staticData.RangeZ.x, _staticData.RangeZ.y);
			return pos;
		}

		private void GetNewPosition(Vector2 point)
		{
			var pos = CalcalutePosition(point);

			foreach (var i in _filterMoverChecker)
			{
				var entityMover = _filterMoverChecker.GetEntity(i);
				entityMover.Get<NewPositionEvent>().value = pos;
			}
		}
	}
}