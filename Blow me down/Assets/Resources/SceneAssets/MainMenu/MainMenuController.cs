using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Play()
    {
        Application.LoadLevel("InGame");
    }

    public void Almanac()
    {
        Application.LoadLevel("Ensiklopedia");
    }

    public void HighScore()
    {
        Application.LoadLevel("HighScore");
    }

    public void Sound()
    {

    }
}
