using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	public GameObject[] items = new GameObject[10];
	public static GameObject[] static_items = new GameObject[10];
	public static int players_item=0;

	int i = 0;
	// Use this for initialization
	void Start () {
		 int players_item=0;

		for(i = 0; i<10;i++){
			static_items[i] = items[i];
		}

	}
	
	// Update is called once per frame
	void Update () {

	}

}
