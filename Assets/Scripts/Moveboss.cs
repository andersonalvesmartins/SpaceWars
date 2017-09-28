using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveboss : MonoBehaviour {
	public float velocidade;
	private bool sobe;
	private int bossLife = 10;
	public GameObject tiroBoss;

	public int shootRate;
	private float currentTime;

	// Use this for initialization
	void Start () {
		currentTime = 0;	
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
		currentTime += Time.deltaTime;
		if(currentTime >= shootRate){
			currentTime = 0;
			GameObject tempPreFab = Instantiate (tiroBoss) as GameObject; 
			tempPreFab.transform.position = new Vector3 (transform.position.x-2, transform.position.y, transform.position.z);
		}
	}
		
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Tiro") {
			bossLife--;
			if (bossLife <= 0) {
				Destroy (transform.gameObject);
				bossLife = 10;
			}
		}
	}
}
