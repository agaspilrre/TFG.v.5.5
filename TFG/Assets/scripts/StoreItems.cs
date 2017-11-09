using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ItemCollection")]
public class StoreItems{

	[XmlArray("Items")]
	[XmlArrayItem("Item")]
	public List<Item> items= new List<Item>();

	public static StoreItems Load(string path){

		TextAsset _xml= Resources.Load<TextAsset>(path);
		Debug.Log ("CAMINO"+path);
		XmlSerializer serializer = new XmlSerializer(typeof(StoreItems)); 

		StringReader reader = new StringReader(_xml.text);

		StoreItems items = serializer.Deserialize(reader) as StoreItems;

		reader.Close();

		return items;
	}
}
