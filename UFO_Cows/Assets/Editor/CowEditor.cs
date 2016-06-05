using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CowGenerator))]
public class CowEditor : Editor {

	// Use this for initialization
	public override void OnInspectorGUI()
	{

		DrawDefaultInspector();
		CowGenerator myTarget = (CowGenerator)target;

		if (GUILayout.Button("Generate"))
		{
			myTarget.GenerateCows();
		}

		if (GUILayout.Button("Clear"))
		{
			myTarget.Clear();
		}
	}

}
