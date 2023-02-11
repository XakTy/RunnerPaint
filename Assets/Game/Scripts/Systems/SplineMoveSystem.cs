using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Zlodey
{
	public sealed class SplineMoveSystem : IEcsRunSystem
	{
		private readonly EcsFilter<SplinePositionerRef>.Exclude<Freeze> _filter;

		private readonly RuntimeData _runtimeData;
		private readonly StaticData _staticData;
		public void Run()
		{
			if (_runtimeData.GameState != GameState.Playing) return;
			foreach (var i in _filter)
			{
				ref var splinePositioner = ref _filter.Get1(i).value;

				var distance = _staticData.BasicSpeedCharacters * _runtimeData.deltaTime;

				float newPosition = Mathf.Clamp((float)splinePositioner.position + distance, 0f, _runtimeData.Lenght);

				splinePositioner.SetDistance(newPosition);
			}
		}
	}
}