using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float EnemySpeed;
    public int EnemyScore = 100;
    public ScoreManager ScoreMngr;
    public GameObject ExplosionAnim;

	// Use this for initialization
	void Start () {
        ScoreMngr = FindObjectOfType<ScoreManager>();   
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMovement();
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
            Destroy(gameObject);    //destroy object if outside camera view
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player Bullet")
        {

            Destroy(other.gameObject);  //destroy player bullet or player if collide
            Destroy(gameObject);    //destroy enemy unit
            ScoreMngr.currentScore += EnemyScore;   //add enemy score to player score manager
            Instantiate(ExplosionAnim, transform.position, transform.rotation); //instantiate explosion animation
        }
        if (other.tag == "Player")
        {
            Instantiate(ExplosionAnim, transform.position, transform.rotation); //instantiate explosion animation
            Destroy(gameObject);    //destroy enemy unit
            ScoreMngr.currentScore += EnemyScore;   //add enemy score to player score manager
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
