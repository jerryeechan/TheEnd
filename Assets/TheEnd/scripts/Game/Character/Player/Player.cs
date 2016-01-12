using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TheEnd;
public class Player : Singleton<Player> {

    public PlayerData data;
    Rigidbody2D rb2d;
    public InteractRangeController interactRangeController;
    Animator anim;
    Vector2 moveVec;
    public bool isCastingBaisema = false;
    public GameObject trigger;
    
    public bool isMoveLocked = false;
    CharacterAnimationState lastState;
    public bool canUseSKill = false;
    public bool isInputEnable = false; 
    void Awake()
	{	
        footStepSound = GetComponent<AudioSource>();
		anim = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        if(interactRangeController == null)
        {
            interactRangeController = GetComponentInChildren<InteractRangeController>();
        }
        
		lastState = CharacterAnimationState.Stand_Front;
	}
    AudioSource footStepSound;
    
    
    public void setMoveVec(Vector2 moveVec)
    {
        if(isInputEnable)
        {
            if(moveVec == Vector2.zero)
            {
                footStepSound.Stop();
            }
            else{
                if(footStepSound.isPlaying == false)
                {
                    footStepSound.Play();  
                }
            }
            this.moveVec = moveVec;
            
            interactRangeController.changeDir(moveVec);    
        }
    }
    public void lockMove ()
    {
        isMoveLocked = true;
        //PlayAnimation(state);
        setMoveVec(Vector2.zero);
    }
    public void unlockMove()
    {
        isMoveLocked = false;
    }
    void Update()
    {
        if (!isCastingBaisema)
        {
            rb2d.velocity = moveVec * data.moveVelocity * SuperUser.instance.su_speed;
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
	
    public void setPosition(MonoBehaviour target,Vector2 delta)
    {
        transform.position = target.GetComponent<Transform>().position + (Vector3)delta;
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
            default:
                state = lastState;break;
			}
		}
		anim.Play (CharacterAnimationStateManager.instance.getAnimationStateString(state));
		//anim.Play(name);
		lastState = state;
	}
    public void damaged(int damageRaw)
    {

    }

    public float getAttackValue()
    {
        return data.damage;
    }
    
    
#region Gesture
    public void skillBtnTouched()
    {
        if(isInputEnable)
        {
           print("skill btn touched");
            if(DialogueManager.instance.isDialoguePlaying)
                DialogueManager.instance.PlayNextLine();
            else if(NoteManager.instance.isPlaying)
                NoteManager.instance.dismissNote();
            else if (UIManager.instance.pickItemView.isPlaying)//獲得物品
                UIManager.instance.pickItemView.Hide();
            else 
            {
                if(!interactRangeController.interact())
                {
                    if(canUseSKill)
                    {
                        SetBaisema();
                    }
                }
            } 
        }
    }
    
    
    public void swipeUp()
    {
        //anim.Play("magic");
        //BaisemaManager.instance.SetUpAll();
    }
    bool isCharging = false;
    public void swipeDown()
    {
        if(canUseSKill)
        {
            isCharging = true;
            Charging();    
        }
        //anim.Play("explode");
        //BaisemaManager.instance.explodeAll();
        
    }
    
    public void release()
    {
        if(isCharging==true)
        {
            Explode();
            isCharging = false;
        }
        
    }
#endregion  
    
    void SetBaisema()
    {
        lockMove();
        anim.Play("magic");
        //Invoke("unlockMove",1f);
        BaisemaManager.instance.genBaisema(transform.position);
        SendMessage("SetBaisemaTriggered");
    }
    void Charging()
    {
        lockMove();
        anim.Play("charging");
    }
    void Explode()
    {
        
        anim.Play("explode");
        BaisemaManager.instance.explodeAll();
        SendMessage("ExplodeTriggered");
    }
}
