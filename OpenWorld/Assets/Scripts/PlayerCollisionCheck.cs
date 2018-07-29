using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionCheck : MonoBehaviour {

	PersistentDataController PDC;

	// Use this for initialization
	void Start () {
		PDC = GameObject.FindGameObjectWithTag("persistentDataController").GetComponent<PersistentDataController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// Show interactPanel when it is touching
		if (col.CompareTag ("tree")) {
			print ("tree");
			// Change to tree scene in AR
			SceneManager.LoadScene ("Tree");
		} else if (col.CompareTag ("fence")) {
			print ("fence");

			SceneManager.LoadScene ("Fence");

		} else if (col.CompareTag ("npc1")) {
			print ("npc1");
			// execute dialog if not played already

			// For now just change to "I need a meatball"
			TextMesh npcText = GameObject.FindGameObjectWithTag (col.tag).transform.parent.GetChild (1).GetComponent<TextMesh> ();
			npcText.text = "I need my meatball";

			// check if owns the clue 1
			PDC.addQuest (1, "go and get his meatball", "Old Man 1");


		} else if (col.CompareTag ("npc2")) {
			print ("npc2");
			// execute dialog

			PDC.addQuest (2, "find magic orb", "Elderly Wizard");


		} else if (col.CompareTag ("npc3")) {
			print ("npc3");

			// execute stuff

			PDC.addQuest (3, "get a Brahim steak", "Saxton Hale");
		} else if (col.CompareTag ("npc4")) {
			print ("npc4");

			// execute stuff

			PDC.addQuest (4, "gather milk by the fence", "Farmer");
		}

		// Places

		else if (col.CompareTag ("FoggyFactoryBog")) {
			// Load it
			SceneManager.LoadScene ("FoggyFactoryBog");
		} else if (col.CompareTag ("MysticMountain")) {

			SceneManager.LoadScene ("MysticMountain");
		} else if (col.CompareTag ("PeacefulForest")) {
			
			SceneManager.LoadScene ("PeacefulForest");
		}
	}
}
