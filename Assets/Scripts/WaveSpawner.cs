using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    private bool isSpawning = false;
    public float minSpawnTime = 0.0f;
    public float maxSpawnTime = 5.0f;
    public GameObject[] enemyPrefab;
    private GameObject enemySpawn;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SpawningEnemy();
	}

    void SpawningEnemy() {
        
        if (!isSpawning)
        {
            isSpawning = true;
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            StartCoroutine(SpawnWave(enemyIndex, Random.Range(minSpawnTime, maxSpawnTime)));
        }
    }

    IEnumerator SpawnWave(int index, float seconds)
    {
        Vector2 minPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        yield return new WaitForSeconds(seconds);
        enemySpawn = (GameObject)Instantiate(enemyPrefab[index], transform.position, transform.rotation);
        enemySpawn.transform.position = new Vector2(Random.Range(minPos.x, maxPos.x), maxPos.y);
        isSpawning = false;
    }
}
