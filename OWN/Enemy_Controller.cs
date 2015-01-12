using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour {

	public GameObject both_enemy;
	int i = 0;
	bool both;
	string s;
	public GUISkin customskin;
	public static bool iscleared;


	// Use this for initialization
	void Start () {
		i=0;
		both_enemy.SetActive(false);
		both = false;
		s = "ボス出現！";
		iscleared = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount==1){
			both = true;
			StartCoroutine("Both");
		}
		if(transform.childCount == 0){
			StartCoroutine("End");
		}
	}

	IEnumerator Both(){
		yield return new WaitForSeconds(3);
			if(transform.childCount>0){
				both_enemy.SetActive(true);
			}
	}


	IEnumerator GUI(){
		yield return new WaitForSeconds(3);
		s = " ";
		if(this.transform.childCount==0){
			s = " CLEAR !!";
			iscleared = true;
		}

	}

	IEnumerator End(){
		yield return new WaitForSeconds(3);
		Destroy(this.gameObject);

	}

		
	void OnGUI(){
		if(both==true){
			//GUI.TextField((-500,Screen.height-400,1000,100)," ");
			GUILayout.BeginArea(new Rect(-500,Screen.height-400 ,2000,300));
			GUILayout.Label(s, customskin.label); 
			GUILayout.EndArea();
			StartCoroutine("GUI");
		}
	}
}
