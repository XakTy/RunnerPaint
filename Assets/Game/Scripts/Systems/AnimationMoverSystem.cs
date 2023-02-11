using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;
using AnimationEvent = Game.Scripts.Components.AnimationEvent;

namespace Zlodey
{
	public sealed class AnimationMoverSystem : IEcsRunSystem
	{
		private readonly EcsFilter<AnimatorRef, AnimationEvent> _filter;
		private static readonly int WIN = Animator.StringToHash("Win");
		private static readonly int RUN = Animator.StringToHash("Run");

		public void Run()
		{
			foreach (var i in _filter)
			{
				foreach (var i1 in _filter)
				{
					var animator = _filter.Get1(i).value;
					var animation = _filter.Get2(i).value;

					switch (animation)
					{
						case AnimationType.idle:
						case AnimationType.Move:
							animator.SetTrigger(RUN);
							break;
						case AnimationType.Win:
							animator.SetTrigger(WIN);
							break;
					}

					var entity = _filter.GetEntity(i);
					entity.Del<AnimationEvent>();
				}
			}
		}
	}
}