using UnityEngine;
using System.Collections;
using TheEnd;
public class Enemy : MonoBehaviour {


    Rigidbody2D rb2d;
    Collider2D c2d;
    public EnemyData data;
    Animator anim;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        c2d = GetComponent<BoxCollider2D>();
        anim = GetComponentInChildren<Animator>();
        lastState = CharacterAnimationState.Stand_Front;
    }


    enum EnemyState { Movable, Trapped, Died };
    EnemyState state = EnemyState.Movable;
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Baisema")
        {
            state = EnemyState.Trapped;
            rb2d.velocity = Vector2.zero;
            c2d.isTrigger = true;
            print("locked");
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        print(collision2D.collider.tag);
        if (collision2D.collider.tag == "Baisema")
        {
            //c2d.isTrigger = true;
        }
    }
    enum EnemyAnimationState { Walk_Back, Walk_Front, Walk_Left, Walk_Right }
    Vector2 moveVec = Vector2.zero;
    public void faceRight()
    {
        transform.localScale = new Vector3(-1,1,1);
    }
    public void faceLeft()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void setMoveVec(Vector2 dir)
    { 
        moveVec = dir;
	}
    CharacterAnimationState lastState;
    public void PlayAnimation(CharacterAnimationState state)
    {
        if (state == CharacterAnimationState.None)
        {
            switch (lastState)
            {
                case CharacterAnimationState.Walk_Back:
                    state = CharacterAnimationState.Stand_Back; break;
                case CharacterAnimationState.Walk_Front:
                    state = CharacterAnimationState.Stand_Front; break;
                case CharacterAnimationState.Walk_Left:
                    state = CharacterAnimationState.Stand_Left; break;
                case CharacterAnimationState.Walk_Right:
                    state = CharacterAnimationState.Stand_Right; break;
            }
        }
        print(CharacterAnimationStateManager.instance);
        string stateName = CharacterAnimationStateManager.instance.getAnimationStateString(state);
        anim.Play(stateName);
        lastState = state;
    }
    void Update()
    {
        rb2d.velocity = moveVec * data.moveVelocity;
    }
    public void takeDamage(float damage)
	{
		data.health -= damage;
		if (data.health<=0)
		{
			DieAnimation();
		}
	} 
	public void DieAnimation()
	{
		state = EnemyState.Died;
		
	}
	
	public void die()
	{
		Destroy(gameObject);
	}
}
