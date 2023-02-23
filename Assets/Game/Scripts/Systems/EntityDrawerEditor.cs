using Leopotam.Ecs;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Zlodey
{
	[CustomPropertyDrawer(typeof(EcsEntity))]
	public class EntityDrawerEditor : PropertyDrawer
	{
		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			var root = new VisualElement();
			var obj = property.serializedObject as object;
			EcsEntity Entity = default;

			if (obj is EcsEntity a)
			{
				Entity = a;
			}
			 

			if (!Entity.IsNull())
			{
				Debug.Log("Em");

				object[] values = new object[Entity.GetComponentsCount()];
				Entity.GetComponentValues(ref values);

				var container = new Box();

				foreach (var component in values)
				{
					var box = new Box();
					var field = new Foldout();

					field.style.unityFontStyleAndWeight = FontStyle.Bold;
					field.text = component.GetType().Name;
					box.Add(field);


					var type = component.GetType();

					field.style.backgroundColor = ComponentColor.GetColor(component.GetType());


					foreach (var fieldInfo in component.GetType().GetFields())
					{

						VisualElement element = new VisualElement();

						if (fieldInfo.GetValue(component) is int value)
						{
							var newObjectField = new IntegerField();
							newObjectField.value = value;

							element = newObjectField;
						}
						else if (fieldInfo.GetValue(component) is string valuestring)
						{
							var newObjectField = new TextField();
							newObjectField.value = valuestring;

							element = newObjectField;
						}
						else if (fieldInfo.GetValue(component) is float valueFloat)
						{
							var newObjectField = new FloatField();
							newObjectField.value = valueFloat;

							element = newObjectField;
						}
						else if (fieldInfo.GetValue(component) is Object valueObject)
						{

							var newObjectField = new ObjectField();
							newObjectField.objectType = valueObject.GetType();
							newObjectField.value = valueObject;

							element = newObjectField;
						}

						field.Add(element);
					}

					container.Add(box);
				}
				root.Add(container);
			}


			return root;
		}

	}
}