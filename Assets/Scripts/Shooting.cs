using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject playerBullet;
	public Transform shotpoint;
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
	}

	void Attack() {
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(playerBullet, shotpoint.position, shotpoint.rotation);
		}
	}
}
