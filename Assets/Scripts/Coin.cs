using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	public SpawnCoins spawner;

	void Start () {
		spawner = FindObjectOfType<SpawnCoins> ();
	}

	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Destroy (gameObject);
		}
	}
		

}
