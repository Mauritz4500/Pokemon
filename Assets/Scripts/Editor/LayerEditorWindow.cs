﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LayerEditorWindow : EditorWindow
{
	public static LayerEditorWindow layerEditorWindow;
	public string fillExpression = "1", path = "world";
	public int selectedLayer = 0;
	public int selectedTile = 0;
	Texture tileTextureAtlas;
	Texture[] tileTextures;

	// Add menu item named "My Window" to the Window menu
	[MenuItem("Editor/Layer Editor")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(LayerEditorWindow));
	}

	void Awake()
	{
		if(!(layerEditorWindow == this || layerEditorWindow == null))
			Debug.LogError("'layerEditorWindow' assigned to different window, reassigning...");
		layerEditorWindow = this;
		tileTextureAtlas = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Graphics/Textures/TestTexture.png", typeof(Texture));
		tileTextures = new Texture[TileRegistry.Tiles.Length];
		int width = (int)(tileTextureAtlas.width * Static.TextureScale), height = (int)(tileTextureAtlas.height * Static.TextureScale);
		for (int i = 0; i < TileRegistry.Tiles.Length; i++)
		{
			tileTextures[i] = new Texture2D(width, height);
			Vector2i textureCoordinates = TileRegistry.Tiles[i].TextureCoordinates(Vector2i.zero, World.world, World.world.Layers[0]);
			Graphics.CopyTexture(tileTextureAtlas, 0, 0, textureCoordinates.x * width, textureCoordinates.y * height, width, height, tileTextures[i], 0, 0, 0, 0);
		}
	}

	void OnGUI()
	{
		if (GUILayout.Button(new GUIContent("Refresh window")))
		{
			Awake();
		}
		path = EditorGUILayout.TextField(new GUIContent("World path", "Path to which the world will be saved to"), path);
		if (GUILayout.Button(new GUIContent("Load world")))
		{
			World.world.Load(path);
			WorldBehaviour.worldBehaviour.RefreshAllLayerBehaviours();
		}
		if (GUILayout.Button(new GUIContent("Save world")))
		{
			World.world.Save(path);
		}
		fillExpression = EditorGUILayout.TextField(new GUIContent("Expression", "Fills a tile at x and y (relative to lower left corner) if the expression evaluates to > 0"), fillExpression);
		for (int i = 0; i < World.world.Layers.Length; i++)
		{
			string text;
			if (i == selectedLayer)
				text = "[Layer " + i.ToString() + "]";
			else
				text = "Layer " + i.ToString();
			if (GUILayout.Button(new GUIContent(text)))
			{
				selectedLayer = i;
				WorldBehaviour.worldBehaviour.CurrentLayer = selectedLayer;
			}
		}
		for (int i = 0; i < tileTextures.Length; i++)
		{
			string text;
			if(i == selectedTile)
				text = "[" + TileRegistry.TileNames[i] + "]";
			else
				text = i.ToString();
			if(GUILayout.Button(new GUIContent(text, tileTextures[i])))
				selectedTile = i;
		}
	}
}
