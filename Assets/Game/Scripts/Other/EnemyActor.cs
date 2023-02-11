using Game.Scripts.Components;
using Leopotam.Ecs;

namespace Zlodey
{
	public class EnemyActor : EntityActor
	{
		public override void Construct()
		{
			Entity.Get<EnemyTag>();
			Entity.Get<TransformRef>().value = transform;
		}
	}
}