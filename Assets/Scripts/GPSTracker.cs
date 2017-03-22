using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSTracker : MonoBehaviour {

	public static GPSTracker Instance { get; set; }

	public Text coordinate;
	public float latitude;
	public float longitude;

	// Use this for initialization
	void Start () {
		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationService());
	}
	
	// Update is called once per frame
	void Update () {
		coordinate.text = "Latitude : " + Instance.latitude.ToString () + "Longitude : " + Instance.longitude.ToString ();
	}

	private IEnumerator StartLocationService(){
		if (!Input.location.isEnabledByUser) {
			Debug.Log ("Turn on your GPS please!");
			yield break;
		}
		Input.location.Start ();
		int maxWait = 20;
		while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		if(maxWait <= 0){
			Debug.Log ("Time out");
			yield break;
		}

		if(Input.location.status == LocationServiceStatus.Failed){
			Debug.Log ("Please go to place with better signal");
			yield break;
		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;
	}
}
