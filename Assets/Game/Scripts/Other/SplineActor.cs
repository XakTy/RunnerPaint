using Dreamteck.Splines;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using System.Collections.Generic;

namespace Zlodey
{
	public class SplineActor : EntityActor
	{
		public SplinePositioner Positioner;
		public List<EntityActor> Childs;
		public override void Construct()
		{
			Entity.Get<SplinePositionerRef>().value = Positioner;
			Entity.Get<Childs>().value = Childs;
		}
	}

	public struct Childs
	{
		public List<EntityActor> value;
	}
}