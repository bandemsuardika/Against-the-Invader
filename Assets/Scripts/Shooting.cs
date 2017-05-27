using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject PlayerBullet;
	public Transform shotpoint;
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;
	public bool IsAuto;

	// Use this for initialization
	void Start () {
		IsAuto = true;
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
	}

	public void Attack() {
		if (IsAuto) {
			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (PlayerBullet, shotpoint.position, shotpoint.rotation);
			}
		}
	}
}
