using Game.Scripts.Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Zlodey
{
	public sealed class AnalyzeTrigger : MonoBehaviour
	{
		public EntityActor Actor;
		public Collider Collider;
		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<AnalyzeTrigger>(out var analyze))
			{
				if (Actor.Entity.IsAlive() && analyze.Actor.Entity.IsAlive())
				{
					var newTriggerEvent = Service<EcsWorld>.Get().NewEntity();

					newTriggerEvent.Get<OnTriggerEnterEvent>() = new OnTriggerEnterEvent()
					{
						EntityA = Actor.Entity,
						EntityB = analyze.Actor.Entity,

						ColliderA = Collider,
						ColliderB = other,
					};
				}

			}
		}

	}
}