using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButtonClick : MonoBehaviour {

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GameObject.FindGameObjectWithTag ("player").GetComponent<Rigidbody2D> ();
		Button myButton = GetComponent<Button> ();
		myButton.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void TaskOnClick(){
		print ("click left");
		// click left
		rb2d.velocity = new Vector2 (-2, 0);
		print (rb2d.velocity);


	}

	void TaskOnTouch(){
		print ("touch left");
		// touch left
		rb2d.velocity = new Vector2 (-2, 0);
	}
}
