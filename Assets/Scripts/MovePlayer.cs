using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public float velocidade;

	public Sprite vidaCheia, vidaMetade, vidaVazia;
	private int playerLife = 3;
	private float alturaMaxima = 3.7f;
	private float alturaMinima = -3.7f;
	private float distanciaMinima = -9f;
	private float distanciaMaxima = 2.5f;

	public GameObject Tiro, Life, Gameover, Boss, Inimigo;

	// Use this for initialization
	void Start () {
		Gameover.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton("Up"))
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y + velocidade, transform.position.z);
		}

		if(Input.GetButton("Down"))
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y - velocidade, transform.position.z);
		}

		if(Input.GetButton("Left"))
		{
			transform.position = new Vector3 (transform.position.x - velocidade, transform.position.y, transform.position.z);
		}

		if(Input.GetButton("Right"))
		{
			transform.position = new Vector3 (transform.position.x + velocidade, transform.position.y, transform.position.z);
		}

		if (transform.position.y >= alturaMaxima) 
		{
			transform.position = new Vector3 (transform.position.x, alturaMaxima, transform.position.z);
		}

		if (transform.position.y <= alturaMinima) 
		{
			transform.position = new Vector3 (transform.position.x, alturaMinima, transform.position.z);
		}

		if (transform.position.x >= distanciaMaxima) 
		{
			transform.position = new Vector3 (distanciaMaxima, transform.position.y, transform.position.z);
		}

		if (transform.position.x <= distanciaMinima) 
		{
			transform.position = new Vector3 (distanciaMinima, transform.position.y, transform.position.z);
		}
		if (Input.GetButtonDown ("Shoot")) {
			GameObject tempPreFab = Instantiate (Tiro) as GameObject;
			tempPreFab.transform.position = new Vector3 (transform.position.x+1, transform.position.y, transform.position.z);	
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Inimigo" || col.tag == "TiroInimigo") {
			playerLife--;
			if (playerLife == 3) {
				Life.GetComponent<SpriteRenderer> ().sprite = vidaCheia;
			}
			if (playerLife == 2) {
				Life.GetComponent<SpriteRenderer> ().sprite = vidaMetade;
			}
			if (playerLife == 1) {
				Life.GetComponent<SpriteRenderer> ().sprite = vidaVazia;
			}

			if (playerLife<=0){
				Gameover.SetActive (true);
				Destroy (transform.gameObject);
				Destroy (Inimigo.transform.gameObject);
				Destroy (Boss.transform.gameObject);
				Destroy (Life.gameObject);
			}
		}
	}
}
