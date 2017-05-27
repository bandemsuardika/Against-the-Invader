using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeState : IEnemyState {

	private EnemyAI enemy;
	private float EvadeTimer;
	private float EvadeDuration = 2f;

	public void Execute (){
		Evade ();
		Debug.Log ("evading");
		/*if (enemy.EnemyStat.Target != null) {
			enemy.ChangeState (new InRangeState ());
		}*/
	}
	public void Enter (EnemyAI monster){
		this.enemy = enemy;
	}
	public void Exit (){

	}
	public void OnTriggerEnter (Collider2D other){

	}

	private void Evade(){
		//turn left or right
		//GetComponent<Rigidbody2D>().velocity = transform.up * enemy.EnemyStat.EnemySpeed;
		EvadeTimer += Time.deltaTime;
		if (EvadeTimer >= EvadeDuration) {
			enemy.ChangeState (new IdleState());
		}
	}
}
