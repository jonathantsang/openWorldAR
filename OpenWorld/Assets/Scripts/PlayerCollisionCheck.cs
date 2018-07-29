using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionCheck : MonoBehaviour {

	PersistentDataController PDC;
	MessageController MC;

	// Use this for initialization
	void Start () {
		PDC = GameObject.FindGameObjectWithTag("persistentDataController").GetComponent<PersistentDataController>();
		MC = GameObject.FindGameObjectWithTag ("messageController").GetComponent<MessageController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// Quests
		List<Quest> quests = PDC.getQuests ();

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

			bool alreadyGotQuest = false;

			for (int i = 0; i < quests.Count; i++) {
				if (quests [i].id == 1) {
					alreadyGotQuest = true;
				}
			}

			// Check if already collected the quest
			if(!alreadyGotQuest){
				// execute dialog if not played already

				// For now just change to "I need a meatball"
				TextMesh npcText = GameObject.FindGameObjectWithTag (col.tag).transform.parent.GetChild (1).GetComponent<TextMesh> ();
				npcText.text = "I need my meatball";

				// Message for added quest
				MC.showMessage("Added Quest: Meatball 1");

				// check if owns the clue 1
				PDC.addQuest (1, "Find his meatball", "Old Man 1");
			}



		} else if (col.CompareTag ("npc2")) {
			print ("npc2");
			// execute dialog

			bool alreadyGotQuest = false;

			for (int i = 0; i < quests.Count; i++) {
				if (quests [i].id == 2) {
					alreadyGotQuest = true;
				}
			}

			// Check if already collected the quest
			if (!alreadyGotQuest) {

				// Message for added quest
				MC.showMessage("Added Quest: Quest for the Magical Orb");

				PDC.addQuest (2, "find magic orb", "Elderly Wizard");

			}

		} else if (col.CompareTag ("npc3")) {
			print ("npc3");

			bool alreadyGotQuest = false;

			for (int i = 0; i < quests.Count; i++) {
				if (quests [i].id == 3) {
					alreadyGotQuest = true;
				}
			}

			// Check if already collected the quest
			if (!alreadyGotQuest) {

				// Message for added quest
				MC.showMessage ("Added Quest: Steak and Fries");

				// execute stuff

				PDC.addQuest (3, "get a Brahim steak", "Saxton Hale");
			}
		} else if (col.CompareTag ("npc4")) {
			print ("npc4");

			// execute stuff

			bool alreadyGotQuest = false;

			for (int i = 0; i < quests.Count; i++) {
				if (quests [i].id == 4) {
					alreadyGotQuest = true;
				}
			}

			// Check if already collected the quest
			if (!alreadyGotQuest) {

				// Message for added quest
				MC.showMessage ("Added Quest: A Farmer's Harvest");

				// execute stuff

				PDC.addQuest (4, "gather milk by the fence", "Farmer");
			}
		}

		// Places

		else if (col.CompareTag ("FoggyFactoryBog")) {
			// Load it
			PDC.relayMessage = "Traveled to Foggy Factory Bog";
			PDC.sceneChange = 1;
			SceneManager.LoadScene ("FoggyFactoryBog");

		} else if (col.CompareTag ("MysticMountain")) {
			PDC.relayMessage = "Traveled to Mystic Mountain";
			PDC.sceneChange = 1;
			SceneManager.LoadScene ("MysticMountain");

		} else if (col.CompareTag ("PeacefulForest")) {
			PDC.relayMessage = "Traveled to Peaceful Forest";
			PDC.sceneChange = 1;
			SceneManager.LoadScene ("PeacefulForest");
		}
	}
}
