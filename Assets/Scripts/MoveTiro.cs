using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTiro : MonoBehaviour {
	public float velocidade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + velocidade, transform.position.y, transform.position.z);	
		if (transform.position.x > 15) {
			Destroy (transform.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag != "Player") {
			Destroy (transform.gameObject);
		}
	}
}
