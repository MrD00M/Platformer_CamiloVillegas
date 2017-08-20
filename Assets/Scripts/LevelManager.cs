using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private string sceneName;
	private float particleDelay = 1.5f;
	public AudioSource Win;

	public ParticleSystem WinParticle;
	// Use this for initialization
	void Start () {
		Scene currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Win.Play ();
			WinParticle.Play ();
			Invoke ("Pass", particleDelay);

		}
	}

	void Pass() {
		if (sceneName == "Lvl1") {
			SceneManager.LoadScene ("Lvl2");
		}

		if (sceneName == "Lvl2") {
			SceneManager.LoadScene ("Lvl3");
		}

		if (sceneName == "Lvl3") {
			SceneManager.LoadScene ("Lvl4");
		}

		if (sceneName == "Lvl4") {
			SceneManager.LoadScene ("Win");
		}
	}
}