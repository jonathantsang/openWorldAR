using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentDataController : MonoBehaviour {

	private int strength = 0;
	private int intelligence = 0;
	private int agility = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setStrength(int strength){
		this.strength = strength;
	}

	public int getStrength(){
		return strength;
	}

	public void setIntelligence(int intelligence){
		this.intelligence = intelligence;
	}

	public int getIntelligence(){
		return intelligence;
	}

	public void setAgility(int agility){
		this.agility = agility;
	}

	public int getAgility(){
		return agility;
	}
}
