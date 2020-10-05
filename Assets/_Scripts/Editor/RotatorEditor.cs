using UnityEngine;
using UnityEditor;

namespace RedHouseGames
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Rotator))]
	public class RotatorEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			// Draw default.
			base.OnInspectorGUI();

			// Update the serializedProperty 
			// - always do this in the beginning of OnInspectorGUI.
			serializedObject.Update();

			if (GUILayout.Button("Set Random Angle"))
			{
				if (serializedObject.isEditingMultipleObjects)
				{
					foreach (var item in serializedObject.targetObjects)
					{
						// Convert.
						Rotator rotator = (Rotator)item;

						// And, apply.
						rotator.SetRandomAngle();
					}
				}
				else
				{
					// Convert.
					Rotator rotator = (Rotator)serializedObject.targetObject;

					// And, apply.
					rotator.SetRandomAngle();
				}
			}

			if (GUILayout.Button("Increase Angular Speed"))
			{
				if (serializedObject.isEditingMultipleObjects)
				{
					foreach (var item in serializedObject.targetObjects)
					{
						// Convert.
						Rotator rotator = (Rotator)item;

						// And, apply.
						rotator.IncreaseRotationSpeed();
					}
				}
				else
				{
					// Convert.
					Rotator rotator = (Rotator)serializedObject.targetObject;

					// And, apply.
					rotator.IncreaseRotationSpeed();
				}
			}

			// Apply changes to the serializedProperty 
			// - always do this in the end of OnInspectorGUI.
			serializedObject.ApplyModifiedProperties();
		}
	}
}
