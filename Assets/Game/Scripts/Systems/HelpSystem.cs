using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;
using AnimationEvent = Game.Scripts.Components.AnimationEvent;

namespace Zlodey
{
	public sealed class HelpSystem : IEcsRunSystem
	{
		private readonly EcsFilter<HelpTag, TransformRef, HelpEvent, RendereRef> _filterHelper;
		private readonly EcsFilter<OnTriggerEnterEvent> _filter;
		private readonly RuntimeData _runtimeData;
		private readonly StaticData _staticData;

		private EcsWorld _world;

		public void Run()
		{

			foreach (var i in _filter)
			{
				ref var entityTrigger = ref _filter.Get1(i);
				var entity = _filter.GetEntity(i);

				if (entityTrigger.EntityA.Has<HelpTag>() && entityTrigger.EntityB.Has<CharacterTag>())
				{
					entityTrigger.EntityA.Get<HelpEvent>().collider = entityTrigger.ColliderB;

					_world.NewEntity().Get<MessageEvent>().value = "HELP";
					_world.NewEntity().Get<MessageEvent>().EntityA = entityTrigger.EntityA;
					_world.NewEntity().Get<MessageEvent>().EntityB = entityTrigger.EntityB;

					entity.Destroy();
					continue;
				}

				if (entityTrigger.EntityB.Has<HelpTag>() && entityTrigger.EntityA.Has<CharacterTag>())
				{
					entityTrigger.EntityB.Get<HelpEvent>().collider = entityTrigger.ColliderA;

					_world.NewEntity().Get<MessageEvent>().value = "HELP";
					_world.NewEntity().Get<MessageEvent>().EntityA = entityTrigger.EntityB;
					_world.NewEntity().Get<MessageEvent>().EntityB = entityTrigger.EntityA;

					entity.Destroy();
					continue;
				}

			}

			foreach (var i in _filterHelper)
			{
				var helper = _filterHelper.Get3(i);


				var transform = _filterHelper.Get2(i).value;
				var render = _filterHelper.Get4(i).value;
				transform.SetParent(helper.collider.transform.parent);

				var materials = render.materials;
				materials[0] = _staticData.YellowMaterial;

				render.materials = materials;

				//render.materials[0].SetColor(StaticData.Color, _staticData.YellowMaterial.color);

				Object.Instantiate(_staticData.HelpParticle, transform.position, Quaternion.identity);

				var entity = _filterHelper.GetEntity(i);
				entity.Del<HelpTag>();
				entity.Del<HelpEvent>();
				entity.Get<AnimationEvent>().value = AnimationType.Move;
				entity.Get<CharacterTag>();
			}
		}
	}
}