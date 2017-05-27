using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour {

    public float Speed;
	public int Attack;
	public int Defend;
    public int CurrentHP;
    public int MaxHP;
    public int CurrentEXP;
    public int EXPRequired;
    public int Level;
	public Text LevelText;
	private int Damage;

    public Boundary boundary;
    public Rigidbody2D rb;
    public GameObject playerBullet;
	public Transform shotpoint, shotpoint2, shotpoint3;
    public float fireRate;
    private float nextFire;
	private bool isLevelUp = false;

    public Slider HPBar;
    public Slider EXPBar;

	public Enemy EnemyStatus;


	// Use this for initialization
	void Start () {
		EnemyStatus = FindObjectOfType<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		Status ();
        HPBar.value = CurrentHP;
        EXPBar.value = CurrentEXP;
    }

	void Status(){
		if (CurrentHP <= 0) {
			CurrentHP = 0;
			Death ();
		} else {
			Movement ();
			//Shooting ();
		}
		if (CurrentEXP >= EXPRequired) {
			LevelUp ();
			isLevelUp = true;
		}
	}

	void Movement() {
		GetComponent<Transform>().position = new Vector2(Mathf.Clamp(GetComponent<Transform>().position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(GetComponent<Transform>().position.y, boundary.yMin, boundary.yMax));
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, 0);
		}
		/*on mobile
		if(Input.acceleration.x){
			GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
		}*/
	}

	/*void Shooting() {
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(playerBullet, shotpoint.position, shotpoint.rotation);
			Instantiate(playerBullet, shotpoint2.position, shotpoint2.rotation);
			Instantiate(playerBullet, shotpoint3.position, shotpoint3.rotation);
		}
	}*/

	void LevelUp(){
		int ExpTemp = CurrentEXP - EXPRequired;
		EXPRequired = (int)((1.4 * EXPRequired) - ((1.4 * EXPRequired) % 10));
		CurrentEXP = ExpTemp;
		Level++;
		LevelText.text = "Level " + Level;
		if (Level % 5 == 1 && isLevelUp == true) {
			Attack += 1;
			Speed += 0.1f;
		}
		if (Level % 5 == 2 && isLevelUp == true) {
			Speed += 0.1f;
			MaxHP += 10;
		}
		if (Level % 5 == 3 && isLevelUp == true) {
			MaxHP += 10;
			Defend += 1;
		}
		if (Level % 5 == 4 && isLevelUp == true) {
			Defend += 1;
			Attack += 1;
		}
		if (Level % 5 == 0 && isLevelUp == true) {
			Attack += 1;
			Speed += 0.1f;
			MaxHP += 10;
			Defend += 1;
		}
		isLevelUp = false;
	}

    void Death()
    {
		Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Enemy" || other.tag == "Meteorite")
        {
			Damage = EnemyStatus.EnemyAttack - Defend;
			if (Damage > 0) {
				CurrentHP -= Damage;
			} else {
				CurrentHP -= 0;
			}
			Destroy(gameObject);
        }
		if (other.tag == "Meteorite") {
			Death ();
		}
    }
}
