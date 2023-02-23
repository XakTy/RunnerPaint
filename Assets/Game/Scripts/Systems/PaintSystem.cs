using Game.Scripts.Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Zlodey
{
	public sealed class PaintSystem : IEcsRunSystem, IEcsInitSystem
	{
		private readonly EcsFilter<PaintWindowRef> _filter;
		private readonly EcsFilter<CharacterTag> _filterMover;
		private PaintWindow _paint;
		private readonly RuntimeData _runtimeData;
		private readonly StaticData _staticData;

		private Line _currentLine;
		public void Run()
		{
			if (_runtimeData.GameState != GameState.Playing) return;


			if (Input.GetMouseButtonDown(0))
			{
				if (_currentLine)
				{
					Object.Destroy(_currentLine.gameObject);
					_currentLine = null;
				}

				_currentLine = Object.Instantiate(_staticData.prefabLine, _paint.transform);
			}

			if (Input.GetMouseButton(0) && _currentLine && _paint.CanPaint)
			{
				var pos = _paint.PaintCamera.ScreenToWorldPoint(Input.mousePosition);
				_currentLine.SetPosition(pos);
			}

			if (Input.GetMouseButtonUp(0) && _currentLine)
			{

				Service<EcsWorld>.Get().NewEntity().Get<EventDeformationPosition>().value = _currentLine.Points;
				Object.Destroy(_currentLine.gameObject);
				_currentLine = null;
			}

		}

		public void Init()
		{
			_paint = _filter.Get1(0).value;
		}
	}
}