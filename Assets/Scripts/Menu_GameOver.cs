using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_GameOver : MonoBehaviour {

	private float timer;
	private Text getTexto;
	private string sceneName;
	public Text texto;

	public int playerLives;
	public int playerCount;


	// Use this for initialization
	void Start () {
		
		Scene currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;

		//myAudioSource = GetComponent<AudioSource> ();

		getTexto = texto.GetComponent<Text> ();
				
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (sceneName == "Menu") {
			
			if (timer > 0.5f) {
				getTexto.enabled = true;
		
			}

			if (timer > 1f) {
				getTexto.enabled = false;
		
				timer = 0;
			}	

			if (Input.GetKey (KeyCode.Space)) {

				PlayerPrefs.SetInt ("PlayerLives", playerLives);
				PlayerPrefs.SetInt ("PlayerCounts", playerCount);

				SceneManager.LoadScene ("Lvl1");
			}
		}

		if (sceneName == "GameOver") {

			if (timer > 0.5f) {
				getTexto.enabled = true;
	
			}

			if (timer > 1f) {
				getTexto.enabled = false;
				timer = 0;
			}	

			if (Input.GetKey (KeyCode.Space)) {
				SceneManager.LoadScene ("Menu");
			}
		}

		if (sceneName == "Win") {

			if (timer > 0.5f) {
				getTexto.enabled = true;

			}

			if (timer > 1f) {
				getTexto.enabled = false;
				timer = 0;
			}	

			if (Input.GetKey (KeyCode.Space)) {
				SceneManager.LoadScene ("Menu");
			}
		}
		
	}


}
