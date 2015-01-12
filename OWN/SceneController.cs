using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(Player_Controller.wasDied==true||Enemy_Controller.iscleared==true){
			if(GUI.Button(new Rect(Screen.width / 2 - 100,Screen.height / 2 - 200,200,50),"リトライ")){
				Item.canUseSword = false;
				Item.charge_medic1 = 0;
				FadeManager.Instance.LoadLevel("Scene1",1.0f,_FadeColor.Black);
				Player_Controller.wasDied = false;
				Enemy_Controller.iscleared = false;
			} 
		}
		if(Player_Controller.wasDied==true||Enemy_Controller.iscleared==true){
			if(this.gameObject.tag == "Scene1"){
				if(GUI.Button(new Rect(Screen.width / 2 ,Screen.height / 2,200,50),"次のシーン")){
					Item.canUseSword = false;
					Item.charge_medic1 = 0;
					FadeManager.Instance.LoadLevel("Scene2",1.0f,_FadeColor.Black);
					Player_Controller.wasDied = false;
					Enemy_Controller.iscleared = false;
				} 
			}
		}
		if(Player_Controller.wasDied==true||Enemy_Controller.iscleared==true){
			if(GUI.Button(new Rect(Screen.width / 2 ,Screen.height / 2 - 100,200,50),"終了")){
				Item.canUseSword = false;
				Item.charge_medic1 = 0;
				FadeManager.Instance.LoadLevel("Title",1.0f,_FadeColor.Black);
				Player_Controller.wasDied = false;
				Enemy_Controller.iscleared = false;
			} 
		}
	}
}
