using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible {

	// Used for storing in the inventory
	public int id;
	public string descrip;
	public Image image;

	public Collectible(int id, string descrip, Image image){
		this.id = id;
		this.descrip = descrip;
		this.image = image;
	}
}
