using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	public int ScoreBonus = 250;
	public int EXPBonus = 25;

	public Player Character;
	public ScoreManager ScoreMngr;
	public GameObject ExplosionAnim;

	// Use this for initialization
	void Start () {
		ScoreMngr = FindObjectOfType<ScoreManager>();  
		Character = FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player" || other.tag == "PlayerBullet")
		{
			Instantiate(ExplosionAnim, transform.position, transform.rotation);
			Destroy(gameObject);	//destroy meteor
			//Destroy (other.gameObject); //destroy player
			ScoreMngr.currentScore += ScoreBonus;   //add bonus score to player score manager
			Character.CurrentEXP += EXPBonus;	//add bonus exp to player
		}
	}
}
