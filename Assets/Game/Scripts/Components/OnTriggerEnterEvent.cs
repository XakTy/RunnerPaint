using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Components
{
	public struct OnTriggerEnterEvent
	{
		public EcsEntity EnterEntity;
		public Collider Collider;
	}
}