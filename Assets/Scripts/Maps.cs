using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maps : MonoBehaviour {

	string url="";

	public float lat = 24f;
	public float lon = 67f;
	LocationInfo li;
	public int Zoom = 14;
	public int mapWidth = 800;
	public int mapHeight = 1280;
	public enum mapType{roadmap, satellite, hybrid, terrain};
	public mapType mapSelected;
	public int scale;

	public bool loadingMap = false;

	private IEnumerator	mapCoroutine;

	IEnumerator GetGoogleMap(float lat, float lon){
		url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon + "&zoom=" + Zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale + "&maptype=" + mapSelected + "&key=AIzaSyCrlIorFL8QbVHtLHNmJttiaZ0YJVXESsM";
		loadingMap = true;
		WWW www = new WWW(url);
		yield return www;
		loadingMap = false;

		//assign download canvas
		gameObject.GetComponent<RawImage>().texture = www.texture;
		StopCoroutine(mapCoroutine);
	}

	// Use this for initialization
	void Start () {
		mapCoroutine = GetGoogleMap (lat, lon);
		StartCoroutine (mapCoroutine);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			Debug.Log ("new map");
			lat = 40f;
			lon = -73f;
			Debug.Log (lat + "," + lon);
			mapCoroutine = GetGoogleMap (lat, lon);
			StartCoroutine (mapCoroutine);
		}
	}
}
