using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointButtonClick : MonoBehaviour {

	public int direction; // 1 for up, -1 for down
	public int id; // 0,1,2 for index in points

	PersistentDataController PDC;

	// Use this for initialization
	void Start () {
		PDC = GameObject.FindGameObjectWithTag ("persistentDataController").GetComponent<PersistentDataController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		// Click, update the persistent Data Controller
		PDC.updatePoint(id, direction);
	}
}
