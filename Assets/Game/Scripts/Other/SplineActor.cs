using Dreamteck.Splines;
using Leopotam.Ecs;
using LeopotamGroup.Globals;

namespace Zlodey
{
	public class SplineActor : EntityActor
	{
		public SplinePositioner Positioner;
		public override void Construct()
		{
			Entity.Get<SplinePositionerRef>().value = Positioner;
		}
	}
}