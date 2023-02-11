using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Zlodey
{
	public sealed class MoveSystem : IEcsRunSystem
	{
		private readonly EcsFilter<CharacterTag, TransformRef, TargetPosition>.Exclude<Freeze> _filterMoverNewPosition;
		private readonly RuntimeData _runtimeData;
		private readonly StaticData _staticData;

		public void Run()
		{
			if (_runtimeData.GameState != GameState.Playing) return;


			foreach (var i in _filterMoverNewPosition)
			{
				var mover = _filterMoverNewPosition.Get2(i).value;
				var position = _filterMoverNewPosition.Get3(i).value;

				mover.transform.localPosition = Vector3.MoveTowards(mover.transform.localPosition, position, _staticData.SpeedEditPosition * _runtimeData.deltaTime);
			}
		}
	}
}