using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	public AudioClip[] musicClip;
	public AudioSource musicSource;
	private bool mainMenuPlayed;
	private bool inGamePlayed;
	private static bool playedBefore = false;

	void Awake(){
		if (!playedBefore) {
			DontDestroyOnLoad (gameObject);
			playedBefore = true;
		}
		else if (playedBefore) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		musicSource = GetComponent<AudioSource> ();
		musicSource.clip = musicClip [0];
		musicSource.Play ();
		mainMenuPlayed = true;
		inGamePlayed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "MainMenu" || Application.loadedLevelName == "Ensiklopedia") {
			if (!mainMenuPlayed) {
				musicSource.Stop ();
				musicSource.clip = musicClip [0];
				musicSource.Play ();
				mainMenuPlayed = true;
				inGamePlayed = false;
			}
		} 
		else if (Application.loadedLevelName == "InGame") {
			if (!inGamePlayed) {
				musicSource.Stop ();
				musicSource.clip = musicClip [1];
				musicSource.Play ();
				mainMenuPlayed = false;
				inGamePlayed = true;
			}
		}
	}
}
