using UnityEngine;
using System.Collections;

public class ContainerController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Close()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    public void Open()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
