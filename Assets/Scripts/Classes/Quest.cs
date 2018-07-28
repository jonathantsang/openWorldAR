using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

	public Quest(int id, string description, string giver){
		this.id = id;
		this.description = description;
		this.giver = giver;
	}

	public int id;
	public string description;
	public string giver;
}
