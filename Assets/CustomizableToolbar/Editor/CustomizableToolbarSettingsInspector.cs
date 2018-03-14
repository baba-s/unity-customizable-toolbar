using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace KoganeEditorLib
{
	[CustomEditor( typeof( CustomizableToolbarSettings ) )]
	public class CustomizableToolbarSettingsInspector : Editor
	{
		private SerializedProperty m_property;
		private ReorderableList m_reorderableList;

		void OnEnable()
		{
			m_property = serializedObject.FindProperty( "m_list" );
			m_reorderableList = new ReorderableList( serializedObject, m_property )
			{
				elementHeight = 80,
				drawElementCallback = OnDrawElement
			};
		}

		private void OnDrawElement( Rect rect, int index, bool isActive, bool isFocused )
		{
			var element = m_property.GetArrayElementAtIndex( index );
			rect.height -= 4;
			rect.y += 2;
			EditorGUI.PropertyField( rect, element );
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			m_reorderableList.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}
	}
}