using Game.Scripts.Components;
using Leopotam.Ecs;

namespace Zlodey
{
	public sealed class EditPositionMoveSystem : IEcsRunSystem
	{
		private readonly EcsFilter<NewPositionEvent> _filter;

		public void Run()
		{
			foreach (var i in _filter)
			{
				var newPosition = _filter.Get1(i).value;

				var entity = _filter.GetEntity(i);
				entity.Get<TargetPosition>().value = newPosition;
				entity.Del<NewPositionEvent>();

			}
		}
	}
}