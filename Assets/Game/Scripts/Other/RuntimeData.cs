using System;
using UnityEngine;

namespace Zlodey
{
    [Serializable]
    public class RuntimeData
    {
        public int Level;
        public GameState GameState;
        public float LevelStartedTime;

        public float deltaTime;

        public float Lenght;

        public MaterialPropertyBlock Block;
    }
}