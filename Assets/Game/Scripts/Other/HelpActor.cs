using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Zlodey
{
	public class HelpActor : EntityActor
	{
		public Animator Animator;
		public Renderer Renderer;
		public CharacterController Controller;

		public override void Construct()
		{
			Entity.Get<HelpTag>();
			Entity.Get<CharacterControllerRef>().value = Controller;
			Entity.Get<RendereRef>().value = Renderer;
			Entity.Get<AnimatorRef>().value = Animator;
			Entity.Get<TransformRef>().value = transform;
		}
	}
}