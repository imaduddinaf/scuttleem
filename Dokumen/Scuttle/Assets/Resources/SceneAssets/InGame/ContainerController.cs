using UnityEngine;
using System.Collections;

public class ContainerController : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
        transform.localScale = new Vector3(1, 1, 1);
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Close()
    {
        //transform.localScale = new Vector3(0, 0, 0);
        this.gameObject.SetActive(false);
    }

    public void Open()
    {
        //transform.localScale = new Vector3(1, 1, 1);
        this.gameObject.SetActive(true);
    }
}
