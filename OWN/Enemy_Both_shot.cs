using UnityEngine;
using System.Collections;

public class Enemy_Both_shot : MonoBehaviour {

	public GameObject bullet;
	float time = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time>=1.0f){
			Instantiate(bullet,this.transform.position,this.transform.rotation);
			time =0 ;
		}

	}

}
