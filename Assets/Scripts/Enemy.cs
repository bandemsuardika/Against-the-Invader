using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int EnemyHP;
	public int EnemyAttack;
	public int EnemyDefend;
    public float EnemySpeed;
	public float EnemyAccel;
    public int ScoreBonus = 100;
	public int EXPBonus = 10;
	public GameObject[] ItemBonus;

	public Player Character;
    public ScoreManager ScoreMngr;
    public GameObject ExplosionAnim;
	private bool IsTurnRight;
	public GameObject Target { get; set; }
	private int DamageTaken;

	// Use this for initialization
	void Start () {
		IsTurnRight = false;
		ScoreMngr = FindObjectOfType<ScoreManager>();  
		Character = FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMovement();
		EnemyStatus ();
		//LookAtTarget ();
    }

	void EnemyStatus(){
		if (EnemyHP <= 0) {
			Instantiate (ExplosionAnim, transform.position, transform.rotation);
			Debug.Log ("1");
			//Destroy (gameObject);
		}
	}

    void EnemyMovement() {
		GetComponent<Rigidbody2D>().velocity = -1 * transform.up * EnemySpeed;
        /*Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - EnemySpeed * Time.deltaTime);
        transform.position = position;*/
        Vector2 minPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y < minPos.y + 1 || transform.position.x < minPos.x + 1 || transform.position.x > maxPos.x - 1)
        {
            //Destroy(gameObject);    //destroy object if outside camera view
        }
    }

	/*private void LookAtTarget(){
		if (Target != null) {
			float xDir = Target.transform.position.x - transform.position.x;
			float yDir = Target.transform.position.y - transform.position.y;
			if (yDir < 0) {
				//rotate to player
			}
		}
	}*/

	/*void Turn(){
		if(transform.position.x > 0){
			//transform.rotation.z = 90;
		}
		if(transform.position.x < 0){
			//transform.rotation.z = -90;
		}
	}*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
			//DamageTaken = Character.Attack - EnemyDefend;
			if (DamageTaken > 0) {
				EnemyHP -= DamageTaken;
				//GetComponent<Animator> ().SetTrigger("Damage");
			}
			Instantiate(ExplosionAnim, transform.position, transform.rotation); //instantiate explosion animation
            Destroy(other.gameObject);  //destroy player bullet or player if collide
			//EnemyHP -= Character.Attack - EnemyDefend;
			//EnemyStatus ();
			Destroy(gameObject);
			ScoreMngr.currentScore += ScoreBonus;   //add enemy score to player score manager
			Character.CurrentEXP += EXPBonus;
        }
        if (other.tag == "Player")
        {
			Debug.Log ("2");
            Instantiate(ExplosionAnim, transform.position, transform.rotation); //instantiate explosion animation
			//EnemyHP -= Character.Attack - EnemyDefend;
			//EnemyStatus ();
			Destroy(gameObject);
			ScoreMngr.currentScore += ScoreBonus;   //add enemy score to player score manager
			Character.CurrentEXP += EXPBonus;
        }
    }

    private void OnBecameInvisible()
    {
        //Destroy(gameObject);
    }
}
