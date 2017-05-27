using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	//[SerializeField]
	public Enemy EnemyStat;

	private IEnemyState currentState;

	// Use this for initialization
	void Start () {
		ChangeState (new IdleState());
	}
	
	// Update is called once per frame
	void Update () {
		currentState.Execute ();
	}

	public void ChangeState(IEnemyState newState){
		if(currentState != null){
			currentState.Exit ();
		}

		currentState = newState;
		currentState.Enter (this);
	}

	void OnTriggerEnter2D(Collider2D other){
		//currentState.OnTriggerEnter (other);
	}
}
