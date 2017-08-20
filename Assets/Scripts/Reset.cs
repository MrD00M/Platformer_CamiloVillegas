using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	public SimplePlatformController Vidas;

	// Use this for initialization
	void Start () {
		Vidas = FindObjectOfType<SimplePlatformController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			if (PlayerPrefs.GetInt("PlayerLives") < 0) {
				SceneManager.LoadScene ("GameOver");

			} else {
				Vidas.BajarVida ();
				Application.LoadLevel (Application.loadedLevel);
			}


		}
	}
}
