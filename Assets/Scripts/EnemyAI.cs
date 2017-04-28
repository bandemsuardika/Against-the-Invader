using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : BaseCharacter {

	[SerializeField]
	private Enemy EnemyStat;

	private IEnemyState currentState;

	// Use this for initialization
	public override void Start () {
		base.Start ();

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
}
