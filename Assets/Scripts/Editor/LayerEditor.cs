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
		LayerBehaviour layerBehaviour = (LayerBehaviour)target;
		Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(new Vector3(e.mousePosition.x, Screen.height - e.mousePosition.y - 36, 0)); //-36 is GUI offset or so
		RaycastHit hit;
		if (e.type == EventType.mouseDown && Physics.Raycast(ray, out hit) && hit.transform.gameObject.GetComponent<LayerBehaviour>() == layerBehaviour)
		{
			Debug.Log(hit);
			Debug.Log(hit.point);
			Vector2i hitPosition = new Vector2i(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));
			Debug.Log(hitPosition);
			Debug.Log(WorldBehaviour.worldBehaviour.World.Layers[LayerEditorWindow.layerEditorWindow.selectedLayer].SetTile(hitPosition, TileRegistry.Tiles[LayerEditorWindow.layerEditorWindow.selectedTile]));
			layerBehaviour.Refresh = true;
			layerBehaviour.Render();
		}
	}
}
