using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveboss : MonoBehaviour {
	public float velocidade;
	private bool sobe;
	private int tiroBoss = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 11.3f) {
			transform.position = new Vector3 (transform.position.x - velocidade, transform.position.y, transform.position.z);
		}
		if (transform.position.y >= 3.6f){
			sobe = false;
		}
		if (transform.position.y <= -3.8f){
			sobe = true;
		}

		if (transform.position.x <= 11.3f && sobe) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + velocidade, transform.position.z);
		}
		if (transform.position.x <= 11.3f && sobe == false) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - velocidade, transform.position.z);
		}
	}
		
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Tiro") {
			tiroBoss++;
			if (tiroBoss == 10) {
				Destroy (transform.gameObject);
				tiroBoss = 0;
			}
		}
	}

}
