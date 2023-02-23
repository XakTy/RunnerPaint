using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using static Dreamteck.Splines.IO.SVG;
using static UnityEditor.Recorder.OutputPath;
using Random = UnityEngine.Random;

namespace Zlodey
{
	public static class ComponentColor
	{
		private static Dictionary<Type, Color> _color = new Dictionary<Type, Color>();

		public static Color GetColor(Type type)
		{
			if (_color.TryGetValue(type, out var color))
			{
				return color;
			}

			var randColor = Random.ColorHSV();
			_color.Add(type, randColor);
			return color;
		}
	}


	//[CustomEditor(typeof(EntityActor), true)]
	//public class EcsDrawerUI : Editor
	//{
	//	public override VisualElement CreateInspectorGUI()
	//	{
	//		var root = new VisualElement();
	//		var entityActor = target as EntityActor;
	//		var prop = serializedObject.GetIterator();
	//		if (prop.NextVisible(true))
	//		{
	//			do
	//			{
	//				var field = new PropertyField(prop);

	//				if (prop.name == "m_Script")
	//				{
	//					field.SetEnabled(false);
	//				}

	//				root.Add(field);
	//			}
	//			while (prop.NextVisible(false));
	//		}

	//		if (!entityActor.Entity.IsNull())
	//		{
	//			object[] values = new object[entityActor.Entity.GetComponentsCount()];
	//			entityActor.Entity.GetComponentValues(ref values);

	//			var container = new Box();

	//			foreach (var component in values)
	//			{
	//				var box = new Box();
	//				var field = new Foldout();

	//				field.style.unityFontStyleAndWeight = FontStyle.Bold;
	//				field.text = component.GetType().Name;
	//				box.Add(field);


	//				var type = component.GetType();

	//				field.style.backgroundColor = ComponentColor.GetColor(component.GetType());


	//				foreach (var fieldInfo in component.GetType().GetFields())
	//				{

	//					VisualElement element = new VisualElement();

	//					if (fieldInfo.GetValue(component) is int value)
	//					{
	//						var newObjectField = new IntegerField();
	//						newObjectField.value = value;

	//						element = newObjectField;
	//					}
	//					else if (fieldInfo.GetValue(component) is string valuestring)
	//					{
	//						var newObjectField = new TextField();
	//						newObjectField.value = valuestring;

	//						element = newObjectField;
	//					}
	//					else if (fieldInfo.GetValue(component) is float valueFloat)
	//					{
	//						var newObjectField = new FloatField();
	//						newObjectField.value = valueFloat;

	//						element = newObjectField;
	//					}
	//					else if (fieldInfo.GetValue(component) is Object valueObject)
	//					{

	//						var newObjectField = new ObjectField();
	//						newObjectField.objectType = valueObject.GetType();
	//						newObjectField.value = valueObject;

	//						element = newObjectField;
	//					}

	//					field.Add(element);
	//				}

	//				container.Add(box);
	//			}
	//			root.Add(container);
	//		}
	//		return root;
	//	}


	//}
}