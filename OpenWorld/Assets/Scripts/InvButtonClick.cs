using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvButtonClick : MonoBehaviour {

	GameObject inventory;

	// Use this for initialization
	void Start () {
		Button myButton = GetComponent<Button> ();
		myButton.onClick.AddListener (TaskOnClick);

		inventory = GameObject.FindGameObjectWithTag ("inventory").gameObject;
		inventory.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		print ("inventory button");
		// Open inventory
		if (inventory.activeInHierarchy) {
			inventory.SetActive (false);
		} else {
			inventory.SetActive (true);
			// Populate the inventory

		}
	}
}
