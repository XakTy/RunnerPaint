using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;
using AnimationEvent = Game.Scripts.Components.AnimationEvent;

namespace Zlodey
{
	public sealed class HelpSystem : IEcsRunSystem
	{
		private readonly EcsFilter<HelpTag, TransformRef, OnTriggerEnterEvent, RendereRef> _filter;
		private readonly RuntimeData _runtimeData;
		private readonly StaticData _staticData;

		public void Run()
		{
			foreach (var i in _filter)
			{
				var trigger = _filter.Get3(i);

				if (trigger.EnterEntity.Has<MoverActorRef>())
				{
					var transform = _filter.Get2(i).value;
					var render = _filter.Get4(i).value;
					transform.SetParent(trigger.Collider.transform.parent);

					render.materials[0].SetColor(StaticData.Color, _staticData.YellowMaterial.color);


					Object.Instantiate(_staticData.HelpParticle, transform.position, Quaternion.identity);


					var entity = _filter.GetEntity(i);
					entity.Del<HelpTag>();
					entity.Get<AnimationEvent>().value = AnimationType.Move;
					entity.Get<CharacterTag>();
				}
			}
		}
	}
}