using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueButtonClick : MonoBehaviour {

	GameObject questLog;
	List<Quest> quests;
	PersistentDataController PDC;


	// Use this for initialization
	void Start () {
		Button myButton = GetComponent<Button> ();
		myButton.onClick.AddListener (TaskOnClick);

		questLog = GameObject.FindGameObjectWithTag ("questLog").gameObject;
		questLog.SetActive (false);

		PDC = GameObject.FindGameObjectWithTag ("persistentDataController").GetComponent<PersistentDataController> ();
		quests = PDC.getQuests ();
	}
	
	// Update is called once per frame
	void Update () {
		if (quests == null) {
			PDC = GameObject.FindGameObjectWithTag ("persistentDataController").GetComponent<PersistentDataController> ();
			quests = PDC.getQuests ();
		}
	}

	void TaskOnClick(){
		print ("quest");
		// Open inventory
		if (questLog.activeInHierarchy) {
			questLog.SetActive (false);
		} else {
			questLog.SetActive (true);
			GameObject questEach = questLog.transform.GetChild (1).gameObject;
			// Populate the questLog
			int len = Mathf.Min(quests.Count, 3);
			for (int i = 0; i < len; i++){
				questEach.transform.GetChild (i).GetChild (0).GetComponent<Text> ().text = "Quest: " + quests [i].id.ToString();
				questEach.transform.GetChild (i).GetChild (1).GetComponent<Text> ().text = "Description: " + quests [i].description.ToString();
				questEach.transform.GetChild (i).GetChild (2).GetComponent<Text> ().text = "Given by: " + quests [i].giver.ToString();
			}
		}
	}
}
