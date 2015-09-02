using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour {
	public static PlayerController instance;
	
	// Use this for initialization
	Rigidbody2D rb2d;
	public Player player;
	void Awake()
	{
		instance = this;
	}
	void Start () {
		rb2d = player.GetComponent<Rigidbody2D>();
		Input.simulateMouseWithTouches = true;
	}
	float velocity = 3f;
	// Update is called once per frame
	float hori = 0;
	float vert = 0;
	void Update () {
		//hori = Input.GetAxis("Horizontal");
		//vert = Input.GetAxis("Vertical");
		//hori = CrossPlatformInputManager.GetAxis("Horizontal");
		//vert = CrossPlatformInputManager.GetAxis("Vertical");
		
		
		/*
		vert = 0;
		hori = 0;
		
		if (Input.GetKey("w"))
			vert = 1;
		if(Input.GetKey("s"))
			vert = -1;
		if (Input.GetKey("a"))
			hori = -1;
		if(Input.GetKey("d"))
			hori = 1;
			*/
		
	}
	Vector2 moveVec;
	float th = Mathf.Sin(22.5f*Mathf.PI/180);
	public void move(Vector2 moveVec)
	{
		Player.PlayerAnimationState state = Player.PlayerAnimationState.None;
		if(moveVec.y>th)
		{
			this.moveVec.y = 1;
			state = Player.PlayerAnimationState.Walk_Front;
		}
		else if(moveVec.y<-th)
		{
			this.moveVec.y = -1;
			state = Player.PlayerAnimationState.Walk_Back;
		}
		else
			this.moveVec.y=  0;
			
		
		if(moveVec.x>th)
		{
			this.moveVec.x = 1;
			state = Player.PlayerAnimationState.Walk_Right;
		}
		else if (moveVec.x<-th)
		{
			this.moveVec.x = -1;
			animation = "walk_left";
			state = Player.PlayerAnimationState.Walk_Left;
		}
		else
			this.moveVec.x=  0;
		
		
		
		this.moveVec = this.moveVec.normalized;
		
		
		player.PlayAnimation(state);
		
		//rb2d.transform.position += (Vector3)moveVec*velocity;
		
	}
	
	public bool isCastingBaisema = false;
	
	void FixedUpdate()
	{
		if(!isCastingBaisema)
			rb2d.velocity = moveVec*velocity;
		//new Vector2(hori,vert).normalized
		else 
			rb2d.velocity = Vector2.zero;
	}
	
	
}
