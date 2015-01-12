using UnityEngine;
using System.Collections;

public class HPgage : MonoBehaviour {
	GUITexture HP;
	private float longth;
	// Use this for initialization
	void Start () {
		HP = GetComponent<GUITexture>();
		longth = 300;
		HP.pixelInset = new Rect(0,0,longth,0);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (spider.Player_damage);
		if(longth-spider.Player_damage>=0.0f){
		HP.pixelInset = new Rect(0,0,longth-spider.Player_damage,0);
		}

	}
}
