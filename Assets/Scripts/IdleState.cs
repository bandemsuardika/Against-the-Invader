using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState {

	private EnemyAI enemy;
	private Enemy enemyStat;
	private float IdleTimer;
	private float IdleDuration = 1f;

	public void Execute (){
		Idle ();
		/*if (enemy.EnemyStat.Target != null) {
			enemy.ChangeState (new EvadeState ());
		}*/
		Debug.Log ("idle");
	}
	public void Enter (EnemyAI monster){
		this.enemy = enemy;
	}
	public void Exit (){
		
	}
	public void OnTriggerEnter (Collider2D other){

	}

	private void Idle(){
		//speed-up
		//enemyStat.EnemySpeed += enemyStat.EnemyAccel;
		/*if(enemy.EnemyStat.Target != null){
			enemy.ChangeState (new InRangeState());
		}*/

		IdleTimer += Time.deltaTime;
		if (IdleTimer >= IdleDuration) {
			enemy.ChangeState (new EvadeState());
		}
	}
}
