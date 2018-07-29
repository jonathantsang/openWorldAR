using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible {

	// Used for storing in the inventory
	public int id;
	public string descrip;
	public Sprite sprite;

	public Collectible(int id, string descrip, Sprite sprite){
		this.id = id;
		this.descrip = descrip;
		this.sprite = sprite;
	}
}
