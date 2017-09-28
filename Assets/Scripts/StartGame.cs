using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	public GameObject GameOver;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetButton ("Shoot")){
				Application.LoadLevel ("SpaceWars");
		}
	}
}
