using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Components
{
	public struct OnTriggerEnterEvent
	{
		public EcsEntity EntityA;
		public EcsEntity EntityB;
		public Collider ColliderA;
		public Collider ColliderB;
	}
}