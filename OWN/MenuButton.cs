using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public static bool isPushed;
	public GameObject menutext;
	// Use this for initialization
	void Start () {
		isPushed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		/*if(GUI.Button(Rect(20, 20, 100, 50), “Button”)){
			Debug.Log(“Button is clicked.”);
		}*/
		if(GUI.Button(new Rect(20,20,100,50),"Menu")){
			if(isPushed == false){
				isPushed = true;
			}
		}

		if(isPushed == true){
				Instantiate(menutext,menutext.transform.position,menutext.transform.rotation);
				Destroy(this.gameObject);
		}


	}
}
