using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvButtonClick : MonoBehaviour {

	GameObject inventory;
	PersistentDataController PDC;
	public Sprite blank;

	// Use this for initialization
	void Start () {
		Button myButton = GetComponent<Button> ();
		myButton.onClick.AddListener (TaskOnClick);

		inventory = GameObject.FindGameObjectWithTag ("inventory").gameObject;
		inventory.SetActive (false);

		PDC = GameObject.FindGameObjectWithTag ("persistentDataController").GetComponent<PersistentDataController> ();
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
			populateInventory();
		}
	}

	void populateInventory() {
		clearInventory ();
		int i = 0;
		List<Collectible> items = PDC.getCollectibles ();
		int len = Mathf.Min (items.Count, 3);
		// Stops at 3
		for (; i < len; i++) {
			inventory.transform.GetChild (1).transform.GetChild (0).GetChild (i).GetComponent<Image> ().sprite = items [i].sprite;
		}
	}

	void clearInventory(){
		for (int i = 0; i < 3; i++) {
			inventory.transform.GetChild (1).transform.GetChild (0).GetChild (i).GetComponent<Image> ().sprite = blank;
		}
	}
}
