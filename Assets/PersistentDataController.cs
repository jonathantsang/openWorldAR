using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentDataController : MonoBehaviour {

	private int strength = 0;
	private int intelligence = 0;
	private int agility = 0;

	GameObject numbers;
	GameObject numLeft;

	// Use this for initialization
	void Start () {
		numbers = GameObject.FindGameObjectWithTag ("numbers").gameObject;
		numLeft = GameObject.FindGameObjectWithTag ("numLeft").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setStrength(int strength){
		this.strength = strength;
	}

	int getStrength(){
		return strength;
	}

	void setIntelligence(int intelligence){
		this.intelligence = intelligence;
	}

	int getIntelligence(){
		return intelligence;
	}

	void setAgility(int agility){
		this.agility = agility;
	}

	int getAgility(){
		return agility;
	}

	public void updatePoint(int id, int direction){
		if (direction == 1) {
			if (strength + intelligence + agility < 10) {
				if (id == 0) {
					strength++;
				} else if (id == 1) {
					intelligence++;
				} else if (id == 2) {
					agility++;
				}
			}
		} else if (direction == -1) {
			if (id == 0 && strength != 0) {
				strength--;
			} else if (id == 1 && intelligence != 0) {
				intelligence--;
			} else if (id == 2 && agility != 0) {
				agility--;
			}
		}
		// Update the text
		updateText();
	}

	void updateText() {
		numbers.transform.GetChild (0).GetComponent<Text> ().text = strength.ToString ();
		numbers.transform.GetChild (1).GetComponent<Text> ().text = intelligence.ToString ();
		numbers.transform.GetChild (2).GetComponent<Text> ().text = agility.ToString ();
		int amtLeft = 10 - strength - intelligence - agility;
		numLeft.GetComponent<Text>().text = amtLeft.ToString ();
	}
}
