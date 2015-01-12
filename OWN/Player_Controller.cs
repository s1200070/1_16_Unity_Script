using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
	public float speed = 1.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public Transform rotatetarget;
	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	public GameObject swordtrail;
	public GameObject sword;
	public static bool wasDied;
	public static int attack_power = 10;

	static int Idlestate = Animator.StringToHash("Base Layer.Idle");
	static int Runstate = Animator.StringToHash("Base Layer.Run");

	static int Kickstate = Animator.StringToHash("Base Layer.kick");
	static int Kickstate00 = Animator.StringToHash("Base Layer.kick00");

	static int Deathstate = Animator.StringToHash("Base Layer.Death");

	
	static int Attackstate01 = Animator.StringToHash("Base Layer.attack01");
	static int Attackstate02 = Animator.StringToHash("Base Layer.attack02");
	static int Attackstate03 = Animator.StringToHash("Base Layer.attack03");
	static int Attackstate04 = Animator.StringToHash("Base Layer.attack04");
	static int Attackstate05 = Animator.StringToHash("Base Layer.attack05");
	static int Damagestate = Animator.StringToHash("Base Layer.Damage");



	void Start(){
		wasDied = false;
		this.gameObject.SetActive(true);
		sword.SetActive(false);
		anim = GetComponent<Animator>();
		swordtrail.SetActive(false);//ソードのエフェクトを攻撃ステート以外表示しない
		ItemGUI.useSword = false;
	}
	
	void FixedUpdate() {
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
		CharacterController controller = GetComponent<CharacterController>();
		moveDirection = Vector3.zero;
		moveDirection.y -= gravity;

		var forward = rotatetarget.TransformDirection(Vector3.forward);
		Vector3 right = new Vector3(forward.z,0,-forward.x);
		var v = -Input.GetAxisRaw("Vertical");
		var h = -Input.GetAxisRaw("Horizontal");
		Vector3 targetDirection = h*right*-1 + v*forward*-1;

		//play running motion when user enters uparrow key , down key , left key, or right key. 
		if(v!=0||h!=0){

			if(currentBaseState.nameHash==Idlestate){
				anim.SetTrigger("Running");
			}
		}

		//play idle motion when user enters noting keys.
		if(h==0&&v==0){
			if(currentBaseState.nameHash==Runstate){
				anim.SetTrigger("Idle");

			}

		}


		//play attack motion when user enters J key or current animation state is Idle state
		if(currentBaseState.nameHash == Idlestate){
			if(spider.player_anim_transitioned=true){
				if(Input.GetKeyDown(KeyCode.J)){
					if(spider.Spider_counter!=0&&ItemGUI.useSword == true&&Item.canUseSword==true){
					anim.SetTrigger("Attack");
					}else if(ItemGUI.useSword == false){
						anim.SetTrigger("Kick");
					}
				}
			}
		}

		if(currentBaseState.nameHash != Idlestate){
			spider.player_anim_transitioned = true;
		}

		if(ItemGUI.useSword==true){
			sword.SetActive(true);
		}
		if(Item.canUseSword==false){
			sword.SetActive(false);
		}

		//play attack motion when user enters J key or current animation state is running state
		if(currentBaseState.nameHash == Runstate){
			if(Input.GetKeyDown(KeyCode.J)){ 
					if(spider.Spider_counter!=0&&ItemGUI.useSword == true&&Item.canUseSword==true){
					anim.SetTrigger("Attack");
					swordtrail.SetActive(true);//ソードのエフェクトを攻撃ステート以外表示しない
				}
				else if(ItemGUI.useSword == false){
					anim.SetTrigger("Kick");
				}
			}
			if(Input.GetKeyDown(KeyCode.H)){
				anim.SetTrigger("Roll");
			}
		}

		if(currentBaseState.nameHash == Deathstate){
			StartCoroutine("Death");
		}

		if (controller.isGrounded) {
			if (Input.GetButton("Jump")){
				moveDirection.y = jumpSpeed;
			}
			
		}

		if((currentBaseState.nameHash == Attackstate04 || currentBaseState.nameHash == Attackstate05||currentBaseState.nameHash == Attackstate02 || currentBaseState.nameHash == Attackstate03)){
			swordtrail.SetActive(true);
			attack_power = 30;
		}else{
			swordtrail.SetActive(false);
			attack_power = 10;
		}

		//player(gameobject) moves forward(deppending values that user enterd).
		if(targetDirection.magnitude > 0.1){
			var rotation = Quaternion.LookRotation(targetDirection);
			rotation.x = 0;
			rotation.z = 0;
			transform.rotation = rotation;
			moveDirection += transform.forward * 20;
		}

		if(currentBaseState.nameHash!=Attackstate01 && currentBaseState.nameHash != Attackstate02 && currentBaseState.nameHash != Attackstate03 && currentBaseState.nameHash != Attackstate04 && currentBaseState.nameHash!=Attackstate05&&currentBaseState.nameHash!=Damagestate&&currentBaseState.nameHash!=Kickstate&&currentBaseState.nameHash!=Kickstate00){
			controller.Move(moveDirection * Time.deltaTime*0.4f);
		}
	}

	IEnumerator Death(){
		yield return new WaitForSeconds(1.5f);
		this.gameObject.SetActive(false);
		wasDied = true; 
	}
}
