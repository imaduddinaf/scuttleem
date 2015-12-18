using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActionButtonController : MonoBehaviour 
{
    public GameObject yellowCannon;
    public GameObject greenCannon;
    public GameObject redCannon;
    public GameObject blueCannon;

    private SkillController skillController;

	// Use this for initialization
	void Start () 
    {
        skillController = GameObject.Find("SkillController").GetComponent<SkillController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    // yellow cannon
    public void YellowCannonFire()
    {
        yellowCannon = GameObject.FindGameObjectWithTag("YellowCannon");
        yellowCannon.GetComponent<ICannon>().Attack();
    }

    // green cannon
    public void GreenCannonFire()
    {
        greenCannon = GameObject.FindGameObjectWithTag("GreenCannon");
        greenCannon.GetComponent<ICannon>().Attack();
    }

    // red cannon
    public void RedCannonFire()
    {
        redCannon = GameObject.FindGameObjectWithTag("RedCannon");
        redCannon.GetComponent<ICannon>().Attack();
    }

    // blue cannon
    public void BlueCannonFire()
    {
        blueCannon = GameObject.FindGameObjectWithTag("BlueCannon");
        blueCannon.GetComponent<ICannon>().Attack();
    }

    public void Up()
    {
        yellowCannon = GameObject.FindGameObjectWithTag("YellowCannon");
        yellowCannon.GetComponent<ICannon>().Upgrade();
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
