using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("tree")) {
			print ("tree");
			// Change to tree scene in AR
		} else if (col.CompareTag ("npc1")) {
			print ("npc1");
			// execute dialog if not played already

			// For now just change to "I need a meatball"
			TextMesh npcText = GameObject.FindGameObjectWithTag (col.tag).transform.parent.GetChild (1).GetComponent<TextMesh> ();
			npcText.text = "I need my meatball";

			// check if owns the sphagetti meatball

		} else if (col.CompareTag ("npc2")) {
			print ("npc2");
			// execute dialog


		}
	}
}
