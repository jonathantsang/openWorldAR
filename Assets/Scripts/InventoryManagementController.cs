using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagementController : MonoBehaviour {

	PersistentDataController persistentDataController;
	List<Collectible> collectibles;

	// Use this for initialization
	void Start () {
		persistentDataController = GameObject.FindGameObjectWithTag ("persistentDataController").GetComponent<PersistentDataController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setCollectibles(List<Collectible> collectibles){
		this.collectibles = collectibles;
	}
}
