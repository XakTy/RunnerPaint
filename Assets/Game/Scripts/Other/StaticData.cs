using UnityEngine;

namespace Zlodey
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Levels")]
        public Levels Levels;
        
        [Header("Required prefabs")]        
        public UI UI;

        [Header("Gameplay variable")] public float TimeToWinLevel = 1; //для примера - время в секундах после которого уровень выигрывается
        public Vector2 RangeX;
        public Vector2 RangeZ;
		public float DelayWin;

		[Header("Character Settings")]
		public float BasicSpeedCharacters;
        public float SpeedEditPosition;

        [Header("Paint Settings")]
		public float Resolution;
        public Line prefabLine;


        [Header("Materials")]
		public Material YellowMaterial;
        public Material DiedMaterial;

        public ParticleSystem HelpParticle;
        public ParticleSystem DiedParticle;


        public static readonly int Color = Shader.PropertyToID("_Color");
    }
}