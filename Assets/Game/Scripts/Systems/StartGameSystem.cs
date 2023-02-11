using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Zlodey
{
	public sealed class StartGameSystem : IEcsRunSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly EcsWorld _world;
        public void Run()
        {
            if (_runtimeData.GameState == GameState.Before)
            {
                if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.IsPointerOverGameObject(0))
                {
                    return;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    _world.ChangeState(GameState.Playing);
                }
            }
        }
    }
}