using UnityEngine;
using System.Collections;

public class ItemGUI : MonoBehaviour {
	//float a;
	string b;
	public static bool useSword = false;
	public GameObject menuButton;

	// Use this for initialization
	void Start () {
	 useSword = false;

	}
	
	// Update is called once per frame
	void Update () {
		b = "回復薬"+Item.charge_medic1 ;
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 250,400,400), "Loader Menu");
		if(Item.canUseSword == true){
			if(GUI.Button(new Rect(Screen.width / 2 - 100,Screen.height / 2 - 200,200,50),"刀を使用する")){
			//isPushed = true;
			if(Item.canUseSword == true){
				useSword = true;
				}if(Item.canUseSword == false){
				useSword = false;
				}
			}
		}
		if(GUI.Button(new Rect(Screen.width / 2 - 100,Screen.height / 2 - 50,200,50),b)){

			if(Item.charge_medic1>=1){
				if(spider.Player_damage > 0){
					spider.Player_damage -= 20;
					Item.charge_medic1 -= 1;
					if(spider.Player_damage<=0){
						spider.Player_damage = 0;
					}
				}
			}

		}

		if(GUI.Button(new Rect(Screen.width / 2 - 100,Screen.height / 2 + 50,200,30),"閉じる")){
			//isPushed = true;
			MenuButton.isPushed = false;
			Instantiate(menuButton,menuButton.transform.position,menuButton.transform.rotation);
			Destroy(this.gameObject);

		}
	}
}
