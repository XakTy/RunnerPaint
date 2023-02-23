using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Components
{
	public struct CharacterTag : IEcsIgnoreInFilter
	{
	}

	public struct CharacterControllerRef
	{
		public CharacterController value;
	}
}