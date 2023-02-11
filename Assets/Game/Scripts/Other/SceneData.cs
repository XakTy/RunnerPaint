using System;
using Dreamteck.Splines;

namespace Zlodey
{
    [Serializable]
    public class SceneData
    {
        public MoverActor[] Actors;
        public SplineComputer Spline;
        public SplineActor SplineActor;
        public PaintWindow PaintActor;
        public EntityActor[] ActorsEntity;
    }
}