using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TheEnd;
public class Player : MonoBehaviour {

	public static Player instance;
    public PlayerData data;
    Rigidbody2D rb2d;
    public AttackRange attackRange;
    Animator anim;
    Vector2 moveVec;
    public bool isCastingBaisema = false;


    CharacterAnimationState lastState;
    void Awake()
	{
		instance = this;
        print(instance);
		anim = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        if(attackRange == null)
        {
            attackRange = GetComponentInChildren<AttackRange>();
        }
        
		lastState = CharacterAnimationState.Stand_Front;
	}
   
    public void setMoveVec(Vector2 moveVec)
    {
        this.moveVec = moveVec;
        attackRange.changeDir(moveVec);
    }

    void Update()
    {
        if (!isCastingBaisema)
        {
            rb2d.velocity = moveVec * data.moveVelocity;
            //print(rb2d.velocity);
        }
        //new Vector2(hori,vert).normalized
        else
            rb2d.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision2d)
	{
		Collider2D collider2D = collision2d.collider;
		switch(collision2d.collider.tag)
		{
			case "Enemy":
				Enemy enemy = collider2D.GetComponent<Enemy>();
				
				break;
			case "Item":
			break;
		}
		
	}
	
    
	public void PlayAnimation(CharacterAnimationState state)
	{
		
		if(state == CharacterAnimationState.None)
		{
			switch(lastState)
			{
			case CharacterAnimationState.Walk_Back:
				state = CharacterAnimationState.Stand_Back;break;
			case CharacterAnimationState.Walk_Front:
				state = CharacterAnimationState.Stand_Front;break;
			case CharacterAnimationState.Walk_Left:
				state = CharacterAnimationState.Stand_Left;break;
			case CharacterAnimationState.Walk_Right:
				state = CharacterAnimationState.Stand_Right;break;
			}
		}
		anim.Play (CharacterAnimationStateManager.instance.getAnimationStateString(state));
		//anim.Play(name);
		lastState = state;
	}
    public void damaged(int damageRaw)
    {

    }
}
