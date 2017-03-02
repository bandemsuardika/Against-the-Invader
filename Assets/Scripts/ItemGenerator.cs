using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    private GameObject itemObj;

	// Use this for initialization
	void Start () {
        spawnStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnStart()
    {
        //spawn position
        Vector2 minPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //instatntiate object
        itemObj = (GameObject)Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        itemObj.transform.position = new Vector2(Random.Range(minPos.x, maxPos.x), maxPos.y);
        Invoke("spawnStart", Random.Range(spawnMin, spawnMax));
        //change position

    }
}
