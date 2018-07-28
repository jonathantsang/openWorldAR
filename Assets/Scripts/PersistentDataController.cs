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

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		inventory = GameObject.FindGameObjectWithTag ("inventory").gameObject;
		inventory.SetActive (false);
		questLog = GameObject.FindGameObjectWithTag ("questLog").gameObject;
		questLog.SetActive (false);

		collectibles = new List<Collectible> ();
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
}
