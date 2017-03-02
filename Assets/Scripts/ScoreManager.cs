using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int currentScore;
    public int bestScore = 0;
    public Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score " + currentScore;
        if (currentScore > bestScore) {
            bestScore = currentScore;
        }
        GameObject.Find("Score").GetComponent<Text>().text = "Score " + currentScore;
        GameObject.Find("Best").GetComponent<Text>().text = "Best " + PlayerPrefs.GetInt("BestScore");
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.Save();
    }
}
