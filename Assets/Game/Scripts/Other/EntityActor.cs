using Leopotam.Ecs;
using LeopotamGroup.Globals;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Zlodey
{
	public abstract class EntityActor : MonoBehaviour
	{
		private EcsEntity _entity;
		public EcsEntity Entity => _entity;
		
		public void Init(EcsWorld world)
		{
			_entity = world.NewEntity();
		}

		public void Init()
		{
			_entity = Service<EcsWorld>.Get().NewEntity();
		}
		public abstract void Construct();
	}
}