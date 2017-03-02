using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    [SerializeField]
    private float BGspeed = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BG();

    }

    void BG() {
        float y = Mathf.Repeat(Time.time * BGspeed, 1);
        Vector2 Offset = new Vector2(0, y);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", Offset);
    }
}
