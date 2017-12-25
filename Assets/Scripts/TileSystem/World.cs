using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Xml;
using System.IO;

public class World
{
	public static World world;
	public Layer[] Layers { get; set; }

	public World(int layers)
	{
		world = this;
		Layers = new Layer[layers];
	}

	public void Save(string folderName)
	{
		if (!Directory.Exists(folderName))
			Directory.CreateDirectory(folderName);
		XmlTextWriter writer = new XmlTextWriter(folderName + "\\data.xml", null);
		writer.WriteStartDocument();
		writer.WriteStartElement("WorldData");
		writer.WriteStartElement("LayerCount");
		writer.WriteValue(Layers.Length);
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndDocument();
		writer.Close();
		string layerPathName = folderName + "\\Layers\\";
		if (!Directory.Exists(layerPathName))
			Directory.CreateDirectory(layerPathName);
		for (int i = 0; i < Layers.Length; i++)
			Layers[i].Save(layerPathName + i.ToString());
	}

	public void Load(string folderName)
	{
		XmlTextReader reader = new XmlTextReader(folderName + "\\data.xml");
		while (reader.Name != "WorldData" && reader.Read()) ;
		while (reader.Name != "LayerCount" && reader.Read()) ;
		reader.Read();
		Layers = new Layer[reader.ReadContentAsInt()];
		string layerPathName = folderName + "\\Layers\\";
		for (int i = 0; i < Layers.Length; i++)
			Layers[i] = new Layer(layerPathName + i.ToString());
	}
}
