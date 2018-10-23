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

			// Check if has the collectible, aka done puzzle
			bool alreadyGotItem = PDC.containsCollectibleId(1);

			if (!alreadyGotItem) {
				// Change to tree scene in AR
				SceneManager.LoadScene ("Tree");
			}


		} else if (col.CompareTag ("fence")) {
			print ("fence");

			// Check if has the collectible, aka done puzzle
			bool alreadyGotItem = PDC.containsCollectibleId(2);

			if (!alreadyGotItem) {
				// Change to tree scene in AR
				SceneManager.LoadScene ("Fence");
			}

		} else if (col.CompareTag("table")){
			print ("table");

			// Check if has the collectible, aka done puzzle
			bool alreadyGotItem = PDC.containsCollectibleId(3);

			if (!alreadyGotItem) {
				// Change to tree scene in AR
				SceneManager.LoadScene ("Table");
			}
		} else if (col.CompareTag ("npc1")) {
			print ("npc1");

			bool alreadyGotQuest = PDC.containsQuestId (1);

			// Check if already collected the quest
			if(!alreadyGotQuest || !PDC.getCompleted(1)){
				// execute dialog if not played already

				// For now just change to "I need a meatball"
				TextMesh npcText = GameObject.FindGameObjectWithTag (col.tag).transform.parent.GetChild (1).GetComponent<TextMesh> ();
				npcText.text = "I need my trophy";

				// Message for added quest
				MC.showMessage("Added Quest: Trophy 1");

				// check if owns the clue 1
				PDC.addQuest (1, "Find his trophy", "Old Man 1");
			}

			if (PDC.containsCollectibleId (1)) {
				// Already got collectible

				// For now just change to "I need a meatball"
				TextMesh npcText = GameObject.FindGameObjectWithTag (col.tag).transform.parent.GetChild (1).GetComponent<TextMesh> ();
				npcText.text = "Thanks for the trophy";

				// Message for added quest
				MC.showMessage("Completed Quest: Trophy 1");

				PDC.removeFromCollectibles (1);

				PDC.removeFromQuests (1);

				PDC.setCompleted (1);
			}

		} else if (col.CompareTag ("npc2")) {
			print ("npc2");
			// execute dialog

			bool alreadyGotQuest = PDC.containsQuestId (2);

			// Check if already collected the quest
			if (!alreadyGotQuest && !PDC.getCompleted(2)) {

				// Message for added quest
				MC.showMessage("Added Quest: Quest for the Magical Piece of Paper");

				PDC.addQuest (2, "find paper of magic", "Elderly Wizard");

			}

			if (PDC.containsCollectibleId (2)) {
				// Already got collectible

				// For now just change to "I need a meatball"
				TextMesh npcText = GameObject.FindGameObjectWithTag (col.tag).transform.parent.GetChild (1).GetComponent<TextMesh> ();
				npcText.text = "Thanks for the magical piece of paper";

				// Message for added quest
				MC.showMessage("Completed Quest: Elderly Wizard");

				PDC.removeFromCollectibles (2);

				PDC.removeFromQuests (2);

				PDC.setCompleted (2);
			}

		} else if (col.CompareTag ("npc3")) {
			print ("npc3");

			bool alreadyGotQuest = PDC.containsQuestId (3);

			// Check if already collected the quest
			if (!alreadyGotQuest && !PDC.getCompleted(3)) {

				// Message for added quest
				MC.showMessage ("Added Quest: Steak and Fries");

				// execute stuff

				PDC.addQuest (3, "get a Brahim steak", "Saxton Hale");
			}

			if (PDC.containsCollectibleId (3)) {
				// Already got collectible

				// For now just change to "I need a meatball"
				TextMesh npcText = GameObject.FindGameObjectWithTag (col.tag).transform.parent.GetChild (1).GetComponent<TextMesh> ();
				npcText.text = "Yum";

				// Message for added quest
				MC.showMessage("Completed Quest: Saxton Hale");

				PDC.removeFromCollectibles (3);

				PDC.removeFromQuests (3);

				PDC.setCompleted (3);
			}

		} else if (col.CompareTag ("npc4")) {
			print ("npc4");

			// execute stuff

			bool alreadyGotQuest = PDC.containsQuestId (4);

			// Check if already collected the quest
			if (!alreadyGotQuest && !PDC.getCompleted(4)) {

				// Message for added quest
				MC.showMessage ("Added Quest: A Farmer's Harvest");

				// execute stuff

				PDC.addQuest (4, "gather milk by the fence", "Farmer");
			}

			if (PDC.containsCollectibleId (4)) {
				// Already got collectible

				// For now just change to "I need a meatball"
				TextMesh npcText = GameObject.FindGameObjectWithTag (col.tag).transform.parent.GetChild (1).GetComponent<TextMesh> ();
				npcText.text = "Yum";

				// Message for added quest
				MC.showMessage("Completed Quest: Saxton Hale");

				PDC.removeFromCollectibles (4);

				PDC.removeFromQuests (4);

				PDC.setCompleted (4);
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

		} else if (col.CompareTag ("SkyCity")) {
			PDC.relayMessage = "Traveled to Sky City";
			PDC.sceneChange = 1;
			SceneManager.LoadScene ("SkyCity");

		} else if (col.CompareTag ("Steampunk")) {
			PDC.relayMessage = "Traveled to Steampunk";
			PDC.sceneChange = 1;

			SceneManager.LoadScene ("Steampunk");
		}
	}
}
