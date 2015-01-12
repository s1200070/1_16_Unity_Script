using UnityEngine;
using System.Collections;

public class Start_Scene1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		FadeManager.Instance.LoadLevel("Scene1",1.0f,_FadeColor.Black);
	}
}
