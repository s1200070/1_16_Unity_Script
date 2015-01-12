using UnityEngine;
using System.Collections;

public class spider : MonoBehaviour {
	public GameObject player;
	public GameObject attack_point;
	public GameObject Fire;
	public static float Player_damage;
	public static int Spider_counter = 0;
	private bool wasFire;
	private bool wasInjured=true;
	private bool calledCorutine = false;
	public static bool player_anim_transitioned = false;
	float px;
	float pz;

	float x;
	float z;

	float distance;
	private int Enemy_life = 40;
	public GameObject item;

	private Animator Player_anim;
	private AnimatorStateInfo Player_currentBaseState;

	private Animator anim;
	private AnimatorStateInfo Spider_currentBaseState;

	/*Player animations*/
	static int Attack01state = Animator.StringToHash("Base Layer.attack01");
	static int Attack02state = Animator.StringToHash("Base Layer.attack02");
	static int Attack03state = Animator.StringToHash("Base Layer.attack03");
	static int Attack04state = Animator.StringToHash("Base Layer.attack04");
	static int Attack05state = Animator.StringToHash("Base Layer.attack05");
	static int kick00state = Animator.StringToHash("Base Layer.kick00");
	static int kickstate = Animator.StringToHash("Base Layer.kick");
	static int Idlestate = Animator.StringToHash("Base Layer.Idle");

	/*Spider animations*/
	static int Attack01state_Spider = Animator.StringToHash("Base Layer.attack");

	bool isSet;

	// Use this for initialization
	void Start () {
		Player_anim = player.GetComponent<Animator>();
		anim = GetComponent<Animator>();
		Spider_counter = 0;
		isSet = false;
		wasFire = false;
		Player_damage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Player_currentBaseState = Player_anim.GetCurrentAnimatorStateInfo(0);
		Spider_currentBaseState = anim.GetCurrentAnimatorStateInfo(0);


		px = attack_point.transform.position.x;
		pz = attack_point.transform.position.z;

		x = this.transform.position.x;
		z = this.transform.position.z;

		distance =Mathf.Sqrt((px - x)*(px - x)+(pz - z)*(pz - z));
		if(Player_currentBaseState.nameHash == Attack01state||Player_currentBaseState.nameHash == Attack02state||Player_currentBaseState.nameHash == Attack03state||Player_currentBaseState.nameHash == Attack04state||Player_currentBaseState.nameHash == Attack05state||Player_currentBaseState.nameHash==kick00state||Player_currentBaseState.nameHash==kickstate){
			if(distance < 1.3){
				if(wasInjured==false){
					Enemy_life = Enemy_life - Player_Controller.attack_power;
					wasInjured = true;
				}
				Debug.Log(Enemy_life);
				if(Enemy_life<=0){
					StartCoroutine("Death");

				}else{
					if(wasInjured==true){
						if(calledCorutine==false){
							StartCoroutine("Damage");
							calledCorutine =true;
						}
					}
				}
			}
		}else {
			wasInjured = false;
			calledCorutine = false;
		}
		if(Player_currentBaseState.nameHash == Idlestate){
			if(distance < 1.0f && Spider_currentBaseState.nameHash == Attack01state_Spider){
				if(Player_damage<=300){
						player_anim_transitioned = true;
						Player_anim.SetTrigger("damage1");
						Player_damage +=5f;
						player_anim_transitioned = false;

				}
			}
				if(Player_damage>300){
					Debug.Log (Player_damage);
					Player_anim.SetTrigger("death");
				}
			}
		}


	IEnumerator Death(){
		yield return new WaitForSeconds(1);
			anim.SetTrigger("death");
			if(wasFire==false){
				Instantiate(Fire,this.gameObject.transform.position+new Vector3(0,0.1f,0),Fire.gameObject.transform.rotation);
				wasFire = true;
			}
		yield return new WaitForSeconds(2f);
		if(isSet==false){
			Instantiate(ItemController.static_items[Spider_counter],this.gameObject.transform.position+new Vector3(0,1,0),item.transform.rotation);
			Spider_counter++;
		}
		isSet = true;

		Destroy(this.gameObject);
	}

	IEnumerator Damage(){
		yield return new WaitForSeconds(1f);
		Instantiate(Fire,this.gameObject.transform.position+new Vector3(0,0.1f,0),Fire.gameObject.transform.rotation);
		anim.SetTrigger("damage");
	}
}
