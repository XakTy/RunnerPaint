using LeopotamGroup.Globals;
using System.Collections.Generic;
using UnityEngine;

namespace Zlodey
{
	public sealed class Line : MonoBehaviour
	{
		[SerializeField] private LineRenderer _renderer;

		private readonly List<Vector2> _points = new();
		public List<Vector2> Points => _points;
		public void SetPosition(Vector2 pos)
		{
			if (!CanAppend(pos)) return;

			_points.Add(transform.parent.InverseTransformPoint(pos));
			_renderer.positionCount++;
			_renderer.SetPosition(_renderer.positionCount - 1, pos);
		}

		private bool CanAppend(Vector2 pos)
		{
			if (_renderer.positionCount == 0) return true;
			return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > Service<StaticData>.Get().Resolution;
		}
	}
}