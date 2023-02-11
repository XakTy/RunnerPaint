using Game.Scripts.Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Zlodey
{
	public class MoverActor : EntityActor
	{
		public Animator Animator;
		public Renderer Renderer;
		public override void Construct()
		{
			Entity.Get<CharacterTag>();
			Entity.Get<RendereRef>().value = Renderer;
			Entity.Get<MoverActorRef>().value = this;
			Entity.Get<AnimatorRef>().value = Animator;
			Entity.Get<TransformRef>().value = transform;
		}
	}
}