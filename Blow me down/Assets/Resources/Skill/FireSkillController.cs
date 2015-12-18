using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireSkillController : MonoBehaviour, ISkillController 
{
    public GameObject fireSkill;
    private GameObject laneSelector;
    private List<Vector2> spawnPosition;

	// Use this for initialization
	void Start () 
    {
        laneSelector = GameObject.Find("FireSkillLaneSelector");
        spawnPosition = new List<Vector2>();
        for (int i = 1; i <= 4; i++)
        {
            GameObject spawnPoint = GameObject.Find("Spawner" + i);
            spawnPosition.Add(new Vector2(2.8f, spawnPoint.transform.position.y - 0.2f));
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SpawnSkill()
    {
        laneSelector.GetComponent<ContainerController>().Open();
    }

    public void SpawnAt(int i)
    {
        GameObject spawnedSkill = (GameObject)Instantiate(fireSkill);
        spawnedSkill.transform.position = spawnPosition[3 - i];
        laneSelector.GetComponent<ContainerController>().Close();
    }

    public void HandleDestroyedSkill(GameObject g)
    {
        throw new System.NotImplementedException();
    }


    public void DisableButton()
    {
        throw new System.NotImplementedException();
    }

    public void EnableButton()
    {
        throw new System.NotImplementedException();
    }
}
