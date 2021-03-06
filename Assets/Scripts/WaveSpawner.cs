﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    private bool isSpawning = false;
    public float minSpawnTime = 0.0f;
    public float maxSpawnTime = 5.0f;
    public GameObject[] enemyPrefab;
    private GameObject enemySpawn;
	public float SpawnDuration = 30.0f;
	public Slider DurationBar;
	private int enemyIndex;

    // Use this for initialization
    void Start () {
		DurationBar.maxValue = SpawnDuration;
	}
	
	// Update is called once per frame
	void Update () {
        SpawningEnemy();
		DurationBar.value = SpawnDuration;
	}

    void SpawningEnemy() {
		if (SpawnDuration > 0) {
			if (!isSpawning) {
				isSpawning = true;
				enemyIndex = Random.Range (0, enemyPrefab.Length);
				StartCoroutine (SpawnWave (enemyIndex, Random.Range (minSpawnTime, maxSpawnTime)));
				Debug.Log ("spawn");
			}
			SpawnDuration -= Time.deltaTime;
		//} else {
		//	StopCoroutine (SpawnWave (enemyIndex, Random.Range (minSpawnTime, maxSpawnTime)));
		//	Debug.Log ("stop");
		}
    }

    IEnumerator SpawnWave(int index, float seconds)
    {
		if (SpawnDuration > 0) {
			Vector2 minPos = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			Vector2 maxPos = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			yield return new WaitForSeconds (seconds);
			enemySpawn = (GameObject)Instantiate (enemyPrefab [index], transform.position, transform.rotation);
			enemySpawn.transform.position = new Vector2 (Random.Range (minPos.x, maxPos.x), maxPos.y);
			isSpawning = false;
		} else
			yield break;
    }
}
