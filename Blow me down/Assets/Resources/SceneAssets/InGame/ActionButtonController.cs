using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ActionButtonController : MonoBehaviour 
{
    public GameObject yellowCannon;
    public GameObject greenCannon;
    public GameObject redCannon;
    public GameObject blueCannon;

	public AudioClip explosionCannon;

    public List<GameObject> cannons;

    private SkillController skillController;

	// Use this for initialization
	void Start () 
    {
        skillController = GameObject.Find("SkillController").GetComponent<SkillController>();

        cannons = new List<GameObject>(4);
        cannons.Add(GameObject.FindGameObjectWithTag("YellowCannon"));
        cannons.Add(GameObject.FindGameObjectWithTag("GreenCannon"));
        cannons.Add(GameObject.FindGameObjectWithTag("RedCannon"));
        cannons.Add(GameObject.FindGameObjectWithTag("BlueCannon"));
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    // yellow cannon
    public void YellowCannonFire()
    {
        //yellowCannon = GameObject.FindGameObjectWithTag("YellowCannon");
        cannons[0].GetComponent<ICannon>().Attack();
		GetComponent <AudioSource> ().PlayOneShot (explosionCannon);
    }

    // green cannon
    public void GreenCannonFire()
    {
        //greenCannon = GameObject.FindGameObjectWithTag("GreenCannon");
        cannons[1].GetComponent<ICannon>().Attack();
		GetComponent <AudioSource> ().PlayOneShot (explosionCannon);
    }

    // red cannon
    public void RedCannonFire()
    {
        //redCannon = GameObject.FindGameObjectWithTag("RedCannon");
        cannons[2].GetComponent<ICannon>().Attack();
		GetComponent <AudioSource> ().PlayOneShot (explosionCannon);
    }

    // blue cannon
    public void BlueCannonFire()
    {
        //blueCannon = GameObject.FindGameObjectWithTag("BlueCannon");
        cannons[3].GetComponent<ICannon>().Attack();
		print ("1");
		GetComponent <AudioSource> ().PlayOneShot (explosionCannon);
    }

    public void Up(int idx)
    {
        //yellowCannon = GameObject.FindGameObjectWithTag("YellowCannon");
        cannons[idx].GetComponent<ICannon>().Upgrade();
    }

    public void FireSkill()
    {
        skillController.DoFireSkill();
        //push button->choose which lane will be burned->spawn fire that damages pirate in that lane (burn effect applies)
    }

    public void IceSkill()
    {
        skillController.DoIceSkill();
        //push button->spawn ice at each of pirate that damages all the pirates (slow effect applied = slowing the pirate down)
    }

    public void ThunderSkill()
    {
        skillController.DoThunderSkill();
        //push button->click where the thunder will come->spawn thunder that damages pirate around it (shock effect applies)
    }
}
