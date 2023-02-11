using Game.Scripts.Components;
using Leopotam.Ecs;
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
			if (other.TryGetComponent<AnalyzeTrigger>(out var entityActor))
			{
				if (Actor.Entity.IsAlive())
				{
					Actor.Entity.Get<OnTriggerEnterEvent>() = new OnTriggerEnterEvent()
					{
						EnterEntity = entityActor.Actor.Entity,
						Collider = entityActor.Collider,
					};
				}

				if (entityActor.Actor.Entity.IsAlive())
				{
					entityActor.Actor.Entity.Get<OnTriggerEnterEvent>() = new OnTriggerEnterEvent()
					{
						EnterEntity = Actor.Entity,
						Collider = Collider,
					};
				}

			}
		}

	}
}