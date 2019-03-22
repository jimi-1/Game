using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int pathLenth;
	public LevelManager theLevel;
	public float moveSpeed = 0.35f;
	public bool v ;
	public Vector2 RespawnPosition;
	private Vector2 dest = Vector2.zero;
	private Rigidbody2D rb;
	private Collider2D cd;
	private Animator animator;

	// Use this for initialization
	void Start () {
		dest = transform.position;
		rb = GetComponent<Rigidbody2D>();
		cd = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	 /* void FixedUpdate2 () {
		Vector2 temp = Vector2.MoveTowards(transform.position,dest,moveSpeed);

		rb.MovePosition(temp);
		if((Vector2)transform.position == dest){
			if((Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)) && Valid(Vector2.right)){
				dest = (Vector2)transform.position + Vector2.right*pathLenth;
			}
			if((Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))&& Valid(Vector2.left)){
				dest = (Vector2)transform.position + Vector2.left*pathLenth;
			}
			if((Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)) && Valid(Vector2.up)){
				dest = (Vector2)transform.position + Vector2.up*pathLenth;
			}
			if((Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))&& Valid(Vector2.down)){
				dest = (Vector2)transform.position + Vector2.down*pathLenth;
			}

			Vector2 dir = dest - (Vector2)transform.position;
			if(dir != new Vector2(0,0) ){
				animator.SetBool("isMove",true);
			}
		}
	}*/

	void FixedUpdate () {
		Vector2 temp = Vector2.MoveTowards(transform.position,dest,moveSpeed);
		rb.MovePosition(temp);
		
		if((Vector2)transform.position == dest){
			if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)){
				dest = (Vector2)transform.position + Vector2.right*pathLenth;
			}
			if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)){
				dest = (Vector2)transform.position + Vector2.left*pathLenth;
			}
			if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)){
				dest = (Vector2)transform.position + Vector2.up*pathLenth;
			}
			if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)){
				dest = (Vector2)transform.position + Vector2.down*pathLenth;
			}

			Vector2 dir = dest - (Vector2)transform.position;
			if(dir != new Vector2(0,0) ){
				animator.SetBool("isMove",true);
			}else{
				RespawnPosition = transform.position;
				animator.SetBool("isMove",false);
			}
		}
	}

	private bool Valid(Vector2 dir){
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos+dir,pos);
		return (hit.collider == cd);
	}
		void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Tree"){
			//Destroy(gameObject);
		}if(col.gameObject.tag == "Water"){
			dest = RespawnPosition;
			theLevel.Respawn();
		}
	}
}

