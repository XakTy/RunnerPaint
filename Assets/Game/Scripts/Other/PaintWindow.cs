using Game.Scripts.Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

namespace Zlodey
{
	public sealed class PaintWindow : EntityActor
	{
		public Camera PaintCamera;
		private bool _canPaint;
		public bool CanPaint => _canPaint;

		private void OnMouseEnter()
		{
			_canPaint = true;
		}

		private void OnMouseExit()
		{
			_canPaint = false;
		}

		public override void Construct()
		{
			Entity.Get<PaintWindowRef>().value = this;
		}
	}
}