using ExpressionParser;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LayerBehaviour))]
public class LayerEditor : Editor
{
	Vector2i firstPosition;
	ExpressionParser.ExpressionParser parser;

	void OnSceneGUI()
	{
		if(parser == null)
			parser = new ExpressionParser.ExpressionParser();
		Event e = Event.current;
		LayerBehaviour layerBehaviour = (LayerBehaviour)target;
		Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(new Vector3(e.mousePosition.x, Screen.height - e.mousePosition.y - 36, 0)); //-36 is GUI offset or so
		RaycastHit hit;
		if (e.type == EventType.MouseDown && e.button == 0 && Physics.Raycast(ray, out hit) && hit.transform.gameObject.GetComponent<LayerBehaviour>() == layerBehaviour)
		{
			firstPosition = new Vector2i(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));
		}
		else if (e.type == EventType.MouseUp && e.button == 0 && Physics.Raycast(ray, out hit) && hit.transform.gameObject.GetComponent<LayerBehaviour>() == layerBehaviour)
		{
			Vector2i secondPosition = new Vector2i(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));
			Vector2i start = new Vector2i(Mathf.Min(firstPosition.x, secondPosition.x), Mathf.Min(firstPosition.y, secondPosition.y));
			Vector2i end = new Vector2i(Mathf.Max(firstPosition.x, secondPosition.x), Mathf.Max(firstPosition.y, secondPosition.y));
			Expression expression = parser.EvaluateExpression(LayerEditorWindow.layerEditorWindow.fillExpression);
			for (int x = start.x; x <= end.x; x++)
				for (int y = start.y; y <= end.y; y++)
				{
					if(expression.Parameters.ContainsKey("x"))
						expression.Parameters["x"].Value = x - start.x;
					if (expression.Parameters.ContainsKey("y"))
						expression.Parameters["y"].Value = y - start.y;
					if (expression.Value > 0)
						Debug.Log(WorldBehaviour.worldBehaviour.World.Layers[LayerEditorWindow.layerEditorWindow.selectedLayer].SetTile(new Vector2i(x, y), TileRegistry.Tiles[LayerEditorWindow.layerEditorWindow.selectedTile]));
				}
			layerBehaviour.Refresh = true;
			layerBehaviour.Update();
		}
	}
}
