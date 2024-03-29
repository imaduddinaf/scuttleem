﻿using UnityEngine;
using System.Collections;

public class SkillController : MonoBehaviour 
{
    public GameObject fireSkillController;
    public GameObject iceSkillController;
    public GameObject thunderSkillController;

	public AudioClip freezeSound;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    
    public void DoFireSkill()
    {
        fireSkillController.GetComponent<ISkillController>().SpawnSkill();
    }

    public void DoIceSkill()
    {
		GetComponent<AudioSource> ().PlayOneShot (freezeSound);
        iceSkillController.GetComponent<ISkillController>().SpawnSkill();
    }

    public void DoThunderSkill()
    {
        thunderSkillController.GetComponent<ISkillController>().SpawnSkill();
    }
}
