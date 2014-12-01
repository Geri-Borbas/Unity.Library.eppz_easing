using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(EPPZEasing_Samples_Renderer))]
public class EPPZEasing_Samples_Renderer_Editor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		((EPPZEasing_Samples_Renderer)target).Align();
	}
}
