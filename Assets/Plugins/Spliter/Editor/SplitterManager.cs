using UnityEditor;
using UnityEngine;

namespace Splitter
{
	[InitializeOnLoad]
	public class SplitterManager
    {
		static SplitterManager()
        {
			EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
		}

		private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
			var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
			if (gameObject == null || !gameObject.TryGetComponent(out Splitter splitter))
			{
				return;
			}
			
			splitter.tag = splitter.EditorOnly ? "EditorOnly" : "Untagged";
			
			var styleState = new GUIStyleState
			{
				textColor = splitter.TextColor,
			};

			var style = new GUIStyle
			{
				normal = styleState,
				fontStyle = splitter.FontStyle,
				alignment = splitter.TextAlignment,
			};

			selectionRect.width += 20;
			if (splitter.Extend)
			{
				// Числа подобранны вручную
				// Информации как получить ширину иерархии не нашёл
				selectionRect.x -= 27.5f;
				selectionRect.width += 23;
			}

			EditorGUI.DrawRect(selectionRect, splitter.BackgroundColor);
			EditorGUI.LabelField(selectionRect, splitter.name, style);
        }
	}
}
