using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour {

	[SerializeField]
	private Enemy enemy;

	//public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			enemy.Target = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			enemy.Target = null;
		}
	}
}
