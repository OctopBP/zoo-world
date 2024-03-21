using UnityEngine;

namespace Splitter
{
	[ExecuteAlways]
	public class Splitter : MonoBehaviour
    {
		#region Unity Serialize Fields
		[Header("Theme")]
		[SerializeField] private Color _textColor = Color.white;
		[SerializeField] private Color _backgroundColor = Color.black;

		[Header("Settings")]
		[SerializeField] private TextAnchor _textAlignment = TextAnchor.MiddleCenter;
		[SerializeField] private FontStyle _fontStyle = FontStyle.Bold;
		[SerializeField] private bool _extend;
		[SerializeField] private bool _editorOnly = true;
		#endregion
		
		public Color TextColor => _textColor;
		public Color BackgroundColor => _backgroundColor;

		public TextAnchor TextAlignment => _textAlignment;
		public FontStyle FontStyle => _fontStyle;
		public bool Extend => _extend;
		public bool EditorOnly => _editorOnly;

		private void Update()
        {
			if (_editorOnly)
            {
				transform.DetachChildren();
			}
		}
	}
}
