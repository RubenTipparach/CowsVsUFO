using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FenceGenerator))]
public class FenceEditor : Editor {

	// Use this for initialization
	public override void OnInspectorGUI() {

		DrawDefaultInspector();
		FenceGenerator myTarget = (FenceGenerator)target;

		if (GUILayout.Button("Generate"))
		{
			myTarget.GenerateFence();
		}

		if (GUILayout.Button("Clear"))
		{
			myTarget.Clear();
		}
	}
	

}
