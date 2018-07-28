using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentDataController : MonoBehaviour {

	private int strength = 0;
	private int intelligence = 0;
	private int agility = 0;

	GameObject inventory;
	GameObject questLog;

	List<Collectible> collectibles; // Used for populating the inventory
	List<Quest> quests; // Used for populating the quests

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		inventory = GameObject.FindGameObjectWithTag ("inventory").gameObject;
		inventory.SetActive (false);
		questLog = GameObject.FindGameObjectWithTag ("questLog").gameObject;
		questLog.SetActive (false);

		collectibles = new List<Collectible> ();
		quests = new List<Quest> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			print ("inventory");
			// Open inventory
			if (inventory.activeInHierarchy) {
				inventory.SetActive (false);
			} else {
				inventory.SetActive (true);
				// Populate the inventory

			}

		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			print ("quest");
			// Open inventory
			if (questLog.activeInHierarchy) {
				questLog.SetActive (false);
			} else {
				questLog.SetActive (true);
				GameObject questEach = questLog.transform.GetChild (1).gameObject;
				// Populate the questLog
				for (int i = 0; i < quests.Count; i++){
					questEach.transform.GetChild (i).GetChild (0).GetComponent<Text> ().text = "Quest: " + quests [i].id.ToString();
					questEach.transform.GetChild (i).GetChild (1).GetComponent<Text> ().text = "Description: " + quests [i].description.ToString();
					questEach.transform.GetChild (i).GetChild (2).GetComponent<Text> ().text = "Given by: " + quests [i].giver.ToString();
				}
			}
		}
	}

	public void setStrength(int strength){
		this.strength = strength;
	}

	public int getStrength(){
		return strength;
	}

	public void setIntelligence(int intelligence){
		this.intelligence = intelligence;
	}

	public int getIntelligence(){
		return intelligence;
	}

	public void setAgility(int agility){
		this.agility = agility;
	}

	public int getAgility(){
		return agility;
	}

	public List<Collectible> getCollectibles(){
		return collectibles;
	}

	public void removeFromCollectibles(int id){
		foreach (Collectible collectible in collectibles) {
			if (collectible.getId () == id) {
				collectibles.Remove (collectible);
			}
		}
	}

	public void addQuest(int i, string description, string giver){
		quests.Add (new Quest(i, description, giver));
	}
}
