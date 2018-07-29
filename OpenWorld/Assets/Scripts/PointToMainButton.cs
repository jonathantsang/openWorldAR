using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointToMainButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onMouseDown(){
		// Save the data in persistent data controller

		// load scene to main
		SceneManager.LoadScene("Main");
	}
		
}
