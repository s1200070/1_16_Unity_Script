using UnityEngine;
using System.Collections;

public class Exit_Explain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		FadeManager.Instance.LoadLevel("Title",1.0f,_FadeColor.Black);
	}
}
