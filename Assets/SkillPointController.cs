using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointController : MonoBehaviour {

	GameObject upObject;
	GameObject numbers;
	GameObject downObject;
	GameObject numLeft;
	PersistentDataController PDC;

	// Use this for initialization
	void Start () {
		numLeft = GameObject.FindGameObjectWithTag ("numLeft").gameObject;
		upObject = GameObject.FindGameObjectWithTag ("up").gameObject;
		numbers = GameObject.FindGameObjectWithTag ("numbers").gameObject;
		downObject = GameObject.FindGameObjectWithTag ("down").gameObject;
		PDC = GameObject.FindGameObjectWithTag ("persistentDataController").GetComponent<PersistentDataController> ();
		intializeSkillPointButtons ();
	}

	void intializeSkillPointButtons() {
		// Top row
		for (int i = 0; i < upObject.transform.childCount; i++) {
			upObject.transform.GetChild (i).GetComponent<SkillPointButtonClick> ().direction = 1;
			upObject.transform.GetChild (i).GetComponent<SkillPointButtonClick> ().id = i;
		}
		// Bottom row
		for (int i = 0; i < downObject.transform.childCount; i++) {
			downObject.transform.GetChild (i).GetComponent<SkillPointButtonClick> ().direction = -1;
			downObject.transform.GetChild (i).GetComponent<SkillPointButtonClick> ().id = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updatePoint(int id, int direction){
		if (direction == 1) {
			if (PDC.getStrength() + PDC.getIntelligence() + PDC.getAgility() < 10) {
				if (id == 0) {
					PDC.setStrength(PDC.getStrength()+1);
				} else if (id == 1) {
					PDC.setIntelligence(PDC.getIntelligence()+1);
				} else if (id == 2) {
					PDC.setAgility(PDC.getAgility()+1);
				}
			}
		} else if (direction == -1) {
			if (id == 0 && PDC.getStrength() != 0) {
				PDC.setStrength(PDC.getStrength()-1);
			} else if (id == 1 && PDC.getIntelligence() != 0) {
				PDC.setIntelligence(PDC.getIntelligence()-1);
			} else if (id == 2 && PDC.getAgility() != 0) {
				PDC.setAgility(PDC.getAgility()-1);
			}
		}
		// Update the text
		updateText();
	}

	void updateText() {
		numbers.transform.GetChild (0).GetComponent<Text> ().text = PDC.getStrength().ToString ();
		numbers.transform.GetChild (1).GetComponent<Text> ().text = PDC.getIntelligence().ToString ();
		numbers.transform.GetChild (2).GetComponent<Text> ().text = PDC.getAgility().ToString ();
		int amtLeft = 10 - PDC.getStrength() - PDC.getIntelligence() - PDC.getAgility();
		numLeft.GetComponent<Text>().text = amtLeft.ToString ();
	}
}
