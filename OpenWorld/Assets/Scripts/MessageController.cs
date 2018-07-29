using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageController : MonoBehaviour {

	PersistentDataController PDC;
	Text message;
	float timer = 0f;
	float showMessageLen = 3f; // 5 seconds

	// Use this for initialization
	void Start () {
		PDC = GameObject.FindGameObjectWithTag ("persistentDataController").GetComponent<PersistentDataController> ();
		message = GetComponent<Text> ();
		message.text = "";

		if (PDC.sceneChange == 1) {
			// display message
			print(PDC.relayMessage);
			message.text = PDC.relayMessage;
			PDC.relayMessage = "";
			PDC.sceneChange = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < showMessageLen) {
			timer += Time.deltaTime;
		} else {
			message.text = "";
			PDC.sceneChange = 0;
			PDC.relayMessage = "";
			timer = 0;
		}
	}

	public void showMessage(string mes){
		timer = 0;
		message.text = mes;
	}
}
