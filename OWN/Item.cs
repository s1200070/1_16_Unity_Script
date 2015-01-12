using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	bool isGet;
	bool isGetMedic;
	MeshRenderer mesh;
	public GUISkin customskin;
	public static int charge_medic1 = 0;
	public static bool canUseSword = false;
	// Use this for initialization
	void Start () {
		isGet = false;
		isGetMedic = false;
		mesh = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			ItemController.players_item++;
			isGet = true;
			isGetMedic = false;
			mesh.enabled = false;
		}
	}

	void OnGUI () {
		GUI.skin = customskin;
		// テキストフィールドを表示する
		if(isGet){
			if(this.gameObject.tag=="item0"){
				GUI.TextField(new Rect(10,Screen.height-130 ,1000,100)," ");
				GUILayout.BeginArea(new Rect(20,Screen.height-130 ,2000,300));
				GUILayout.Label("刀を手に入れた！", customskin.label); 
				canUseSword = true;
				GUILayout.EndArea();
			}
			if(this.gameObject.tag =="item1"){
				GUI.TextField(new Rect(10,Screen.height-130 ,1000,100)," ");
				GUILayout.BeginArea(new Rect(20,Screen.height -130,2000,300));
				GUILayout.Label("回復薬を手に入れた", customskin.label); 
				if(isGetMedic==false){
					charge_medic1++;
				}
				isGetMedic = true;
				GUILayout.EndArea();
			}
			StartCoroutine("DestroyItem");
		}
	}

	IEnumerator DestroyItem(){
		yield return new WaitForSeconds(1);
		isGetMedic = false;
		Destroy(this.gameObject);
	}
}
