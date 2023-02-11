using Leopotam.Ecs;

namespace Zlodey
{
    public sealed class InitializeSystem : IEcsInitSystem
    {
        private readonly UI _ui;
        private readonly EcsWorld _world;
        private readonly RuntimeData _runtimeData;
        private readonly SceneData _sceneData;

        public void Init()
        {
            _ui.CloseAll();
            _runtimeData.Level = Progress.CurrentLevel;
            _world.ChangeState(GameState.Before);

            _runtimeData.Lenght = _sceneData.Spline.CalculateLength();

            _sceneData.SplineActor.Init(_world);
            _sceneData.SplineActor.Construct();
            _sceneData.PaintActor.Init(_world);
            _sceneData.PaintActor.Construct();

            foreach (var entityActor in _sceneData.ActorsEntity)
            {
	            entityActor.Init(_world);
	            entityActor.Construct();
            }
        }
    }
}