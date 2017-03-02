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
    public int CurrentHP;
    public int MaxHP;
    public int CurrentEnergy;
    public int MaxEnergy;
    public int Level;

    public Boundary boundary;
    public Rigidbody2D rb;
    public GameObject playerBullet;
    public Transform shotpoint;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public Slider HPBar;
    public Slider EnergyBar;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Shooting();
        HPBar.value = CurrentHP;
        EnergyBar.value = CurrentEnergy;
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
    }

    void Shooting() {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(playerBullet, shotpoint.position, shotpoint.rotation);
        }
    }

    void Death()
    {
        if(CurrentHP == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            CurrentHP--;
            Destroy(gameObject);
        }
    }
}
