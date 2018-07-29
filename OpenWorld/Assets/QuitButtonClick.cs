using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button myButton = GetComponent<Button> ();
		myButton.onClick.AddListener (TaskOnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	void TaskOnClick(){
		print ("quit button in AR");
		if (SceneManager.GetActiveScene ().name == "Tree") {
			
			SceneManager.LoadScene ("FoggyFactoryBog");
		} else if (SceneManager.GetActiveScene ().name == "Fence") {
			
			SceneManager.LoadScene ("MysticMountain");
		}

	}
}
