using UnityEngine;
using System.Collections;

public class SpawnedTextBehaviour : MonoBehaviour 
{
    public float destroyTime;
    private bool destroyed = false;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(CountSeconds(destroyTime));
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (destroyed)
            GameObject.Destroy(this.gameObject);
        Vector2 tmpPos = this.transform.position;
        this.transform.position = new Vector2(tmpPos.x, tmpPos.y + Time.deltaTime);
	}

    IEnumerator CountSeconds(float n)
    {
        yield return new WaitForSeconds(n);
        destroyed = true;
    }
}
