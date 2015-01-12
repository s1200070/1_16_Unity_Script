using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += transform.forward*0.3f;
		Destroy(this.gameObject,3);
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			//col.gameObject.SetActive(false);
			spider.Player_damage += 50;
		}
	}
}
