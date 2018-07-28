using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

	int id {
		get {
			return this.id;
		}
		set {
			this.id = value;
		}
	}
	string description{
		get {
			return this.description;
		}
		set {
			this.description = value;
		}
	}
	string giver {
		get {
			return this.giver;
		}
		set {
			this.giver = value;
		}
	}
}
