using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible {

	// Used for storing in the inventory
	int id;
	Image image;

	Collectible(){
	}

	public int getId(){
		return id;
	}

	public void setId(int id){
		this.id = id;
	}

	public Image getImage(){
		return image;
	}

	public void setImage(Image image){
		this.image = image;
	}
}
