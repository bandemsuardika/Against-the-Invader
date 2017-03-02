using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float BulletSpeed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up * BulletSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
