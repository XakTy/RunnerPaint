using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;
using AnimationEvent = Game.Scripts.Components.AnimationEvent;
using Random = UnityEngine.Random;

namespace Zlodey
{
	public sealed class WinSystem : IEcsRunSystem
	{
		private readonly EcsFilter<WinEvent> _filter;
		private readonly EcsFilter<CharacterTag, TransformRef> _filterMover;
		private readonly StaticData _staticData;
		private readonly EcsWorld _world;
		public void Run()
		{
			foreach (var i in _filter)
			{
				var winEvent = _filter.Get1(i);

				foreach (var indexMover in _filterMover)
				{
					var entity = _filterMover.GetEntity(indexMover);
					var transform = _filterMover.Get2(indexMover).value;

					var randmoze = Random.insideUnitCircle;
					Vector3 pos = new Vector3(winEvent.value.position.x * randmoze.x * 0.1f, transform.position.y, winEvent.value.position.z * randmoze.y * 0.01f);
					entity.Get<TargetPosition>().value = pos;
				}

				DelayWin();

				_filter.GetEntity(i).Destroy();
			}
		}

		private async UniTask DelayWin()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(_staticData.DelayWin));

			foreach (var indexMover in _filterMover)
			{
				var transform = _filterMover.Get2(indexMover).value;

				transform.rotation = Quaternion.LookRotation(-transform.forward);

				var entity = _filterMover.GetEntity(indexMover);
				entity.Get<AnimationEvent>().value = AnimationType.Win;
			}

			_world.ChangeState(GameState.Win);
		}
	}
}