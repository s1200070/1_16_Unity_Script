using UnityEngine;
using System.Collections;

public class Watch_Explain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		FadeManager.Instance.LoadLevel("Explain",1.0f,_FadeColor.Black);
	}
}
