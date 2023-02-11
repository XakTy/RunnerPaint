using Game.Scripts.Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Zlodey
{
	public sealed class WinZone : MonoBehaviour
	{
		public Collider Collider;
		public Transform WinPoint;
		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<MoverActor>(out _))
			{
				Service<EcsWorld>.Get().NewEntity().Get<WinEvent>().value = WinPoint;
				Collider.enabled = false;

			}
		}
	}
}