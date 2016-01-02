using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnsiklopediaController : MonoBehaviour 
{
    public GameObject pirateDemo;
    public GameObject pirateName;
    public GameObject pirateDescription;
    public GameObject pirateKillCount;
    private MasterData masterData;

	// Use this for initialization
	void Start () 
    {
        masterData = GameObject.Find("MasterData").GetComponent<MasterData>();
        LoadInformation(0);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SelectPirate(int idx)
    {
        LoadInformation(idx);
    }

    private void LoadInformation(int idx)
    {
        //Debug.Log("load " + idx);
        pirateDemo.GetComponent<Animator>().runtimeAnimatorController = masterData.piratePrefabs[idx].GetComponent<Animator>().runtimeAnimatorController;
        pirateDemo.GetComponent<Animator>().Play("Idle");
        pirateName.GetComponent<Text>().text = masterData.piratePrefabs[idx].GetComponent<IShip>().ShipName;
        pirateDescription.GetComponent<Text>().text = masterData.piratePrefabs[idx].GetComponent<IShip>().ShipDescription;
        pirateKillCount.GetComponent<Text>().text = "Kill count : " + masterData.killCount[idx].ToString();
    }
}
