using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PickButton))]
public class PickInspector : Editor
{
	string Character = "";
	public override void OnInspectorGUI(){
//		Game.Char1 = EditorGUILayout.ObjectField("Character:", Character, typeof(string), false) as MonoScript;
     }
}

