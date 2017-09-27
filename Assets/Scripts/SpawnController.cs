using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject inimigo;
	public GameObject boss;

	private int contador;

	public float rateSpawn;
	private float currentTime;
	private float posicao;

	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime >= rateSpawn && contador < 6) 
		{
			contador++;
			currentTime = 0;
			posicao = Random.Range (-3.7f, 3.4f);

			GameObject tempPrefab = Instantiate (inimigo) as GameObject;
			tempPrefab.transform.position = new Vector3 (tempPrefab.transform.position.x, posicao, tempPrefab.transform.position.z);
		}

		if (currentTime >= rateSpawn && contador == 6) {
			contador++;
			currentTime = 0;

			GameObject tempPreFab = Instantiate (boss) as GameObject;
			tempPreFab.transform.position = new Vector3 (tempPreFab.transform.position.x, tempPreFab.transform.position.y, tempPreFab.transform.position.z);
		
		}


	}
}
