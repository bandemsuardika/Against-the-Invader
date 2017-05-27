using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeState : IEnemyState {

	private EnemyAI enemy;

	public void Execute (){
		if (enemy.EnemyStat.Target != null) {
			enemy.ChangeState (new BattleAttackState ());
		}
	}
	public void Enter (EnemyAI monster){
		this.enemy = enemy;
	}
	public void Exit (){

	}
	public void OnTriggerEnter (Collider2D other){

	}
}
