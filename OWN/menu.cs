using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	public GameObject itemGUI;
	public GameObject menuButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 250,400,400), "Loader Menu");
		if(GUI.Button(new Rect(Screen.width / 2 - 100,Screen.height / 2 - 200,200,50),"アイテム")){
			Instantiate(itemGUI,itemGUI.transform.position,itemGUI.transform.rotation);
			Destroy(this.gameObject);
		}
		if(GUI.Button(new Rect(Screen.width / 2 - 100,Screen.height / 2 + 50,200,30),"閉じる")){
			//isPushed = true;
			MenuButton.isPushed = false;
			Instantiate(menuButton,menuButton.transform.position,menuButton.transform.rotation);
			Destroy(this.gameObject);
			
		}
	}
}
