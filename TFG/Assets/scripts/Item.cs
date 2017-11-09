using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;


public class Item{


	[XmlAttribute("name")]
	public string name;

	[XmlElement("Dmg")]
	public float dmg;

	[XmlElement("Durability")]
	public float durability;

	[XmlElement("Dialogue")]
	public string dialogue;

	[XmlElement("Decision")]
	public string decision;

	public string getName(){

		return name;
	}

	public string getDialogue(){

		return dialogue;
	}

	public string getDecision(){

		return decision;
	}
}
