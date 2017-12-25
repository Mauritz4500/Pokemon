using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LayerBehaviour))]
public class LayerEditor : Editor
{
	void OnSceneGUI()
	{
		Event e = Event.current;
		Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(new Vector3(e.mousePosition.x, Screen.height - e.mousePosition.y, 0));
		RaycastHit hit;
		if (e.type == EventType.MouseDown)
		{
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log(hit);
			}
		}
	}
}
