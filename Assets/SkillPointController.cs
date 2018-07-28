using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointController : MonoBehaviour {

	GameObject upObject;
	GameObject numbers;
	GameObject downObject;

	// Use this for initialization
	void Start () {
		upObject = GameObject.FindGameObjectWithTag ("up").gameObject;
		numbers = GameObject.FindGameObjectWithTag ("numbers").gameObject;
		downObject = GameObject.FindGameObjectWithTag ("down").gameObject;
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
}
