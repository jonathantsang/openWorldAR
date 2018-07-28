using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTextController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TextMesh textBubble = transform.GetChild (1).GetComponent<TextMesh> ();
		// Turn off by default
		textBubble.text = ""; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
