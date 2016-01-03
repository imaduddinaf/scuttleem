using UnityEngine;
using System.Collections;

public class SoundPirate : MonoBehaviour {

	public AudioClip soundBasic;
	public AudioClip soundBoss;

	// Use this for initialization
	void Start () {
	
	}

	public void SoundPirates(int x){
		if (x == 0 || x == 1) {
			GetComponent <AudioSource> ().PlayOneShot (soundBasic);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
