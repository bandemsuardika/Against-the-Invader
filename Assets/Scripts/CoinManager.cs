using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

    public int currentCoin = 0, stageCoin = 0;
    private int playerCoin; //jumlah semua coin
    private int bcoin, scoin, gcoin;
    public Text BcoinText, ScoinText, GcoinText;
    
	// Use this for initialization
	void Start () {
        currentCoin = PlayerPrefs.GetInt("Coins", 0);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateStageCoin();
        //stageCoin = currentCoin;
    }

    private void UpdateStageCoin() {
        // 1G = 10S, 1S=10B, total (B) = B + 10*S + 100*G
        //coinText.text = currentCoin.ToString();
        //jika terjadi penambahan bronze coin

        //Debug.Log("coin: " + currentCoin);
        if (bcoin % 10 > 0)
        {
            bcoin = bcoin % 10;
            currentCoin++;
            BcoinText.text = bcoin.ToString();
        }
        //jika bronze coin kelipatan 10 maka akan menjadi 0 
        if (bcoin > 0 && bcoin % 10 == 0)
        {
            currentCoin++;
            BcoinText.text = "0";
        }
        //jika bronze coin lebih dari sepuluh maka 1 ditambahkan pada silver coin
        if (bcoin / 10 > 0 && bcoin % 10 == 0)
        {
            scoin++;
            ScoinText.text = scoin.ToString();
        }
        //jika silver coin kelipatan 10 maka akan menjadi 0 
        if (scoin % 10 == 0)
        {
            ScoinText.text = "0";
        }
        //jika silver coin lebih dari sepuluh maka 1 ditambahkan pada gold coin
        if (scoin / 10 > 0 && scoin % 10 == 0)
        {
            gcoin++;
            GcoinText.text = gcoin.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Star")
        {
            bcoin++;
            UpdateStageCoin();
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        playerCoin = playerCoin + stageCoin;
        PlayerPrefs.GetInt("StageCoin", stageCoin);
        //PlayerPrefs.SetInt("Coins", currentCoin);
        PlayerPrefs.GetInt("PlayerCoin", playerCoin);
        PlayerPrefs.DeleteKey("StageCoin");

    }
}
