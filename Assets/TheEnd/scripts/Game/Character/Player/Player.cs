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
    public bool canUseSkill = false;
    public bool isInputEnable = false; 
    
    public Animator moshiue;
    public Animator shiunyin;
    Animator[]  characters;
    public BloodSplash hurtEffect;
    PlayerEffect effectPlayer;
    public SoundPlayer voiceManager;
    void Awake()
	{	
        footStepSound = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        characters = GetComponentsInChildren<Animator>();
        if(interactRangeController == null)
        {
            interactRangeController = GetComponentInChildren<InteractRangeController>();
        }
        
		lastState = CharacterAnimationState.Stand_Front;
        bool skillTemp = canUseSkill;
        SwitchCharacter(MainCharacterEnum.moshiue);
        canUseSkill = skillTemp;
        //SwitchCharacter(MainCharacterEnum.shiunyin);
        effectPlayer = GetComponent<PlayerEffect>();
	}
    
    public MainCharacterEnum current_ch;
    public void SwitchCharacter(MainCharacterEnum ch)
    {
        switch (ch)
        {
            case MainCharacterEnum.moshiue:
                anim = moshiue;
                disableCharacters();
                moshiue.gameObject.SetActive(true);
                canUseSkill = true;
                break;
            case MainCharacterEnum.shiunyin:
                anim = shiunyin;
                disableCharacters();
                shiunyin.gameObject.SetActive(true);
                canUseSkill = false;
                break;
            default:
                anim = moshiue;
                break;
        }
        current_ch = ch;
        PlayAnimation(lastState);
    }
    void disableCharacters()
    {
        foreach(Animator ch in characters)
        {
            ch.gameObject.SetActive(false);
        }
    }
    AudioSource footStepSound;
    
    public void setMoveVec(Vector2 moveVec)
    {
        if(isInputEnable)
        {
            if(state==PlayerState.Moving)
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
    }
    public void lockMove ()
    {
        isMoveLocked = true;
        //PlayAnimation(state);
        //setMoveVec(Vector2.zero);
    }
    public void unlockMove()
    {
        isMoveLocked = false;
        state = PlayerState.Moving;
    }
    void Update()
    {
        
        if (!isMoveLocked)
        {
            rb2d.velocity = moveVec * data.moveVelocity * SuperUser.instance.su_speed;
            //print(rb2d.velocity);
        }
        else
            rb2d.velocity = Vector2.zero;
        
        
        
        if(!isMoveLocked)
        {
           bool isItemInFront = interactRangeController.testInteract();
           if(isItemInFront)
            SkillBtn.instance.changeMode(SkillBtn.SkillBtnMode.Investigate);
           else
            SkillBtn.instance.changeMode(SkillBtn.SkillBtnMode.Baisema);    
        }
        
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
    
    
    
#region Gesture
    public void skillBtnTouched()
    {
        
        isMoveLocked = false;
        if(isInputEnable&&state==PlayerState.Moving)
        {
           
           print("skill btn touched");
           hasInteracted = true;
            if(DialogueManager.instance.isDialoguePlaying)
                DialogueManager.instance.PlayNextLine();
            else if(NoteManager.instance.isPlaying)
                NoteManager.instance.dismissNote();
            else if (UIManager.instance.pickItemView.isPlaying)//獲得物品
                UIManager.instance.pickItemView.Hide();
            else if (UIManager.instance.bagView.isPlaying)
                UIManager.instance.bagView.useItem();
            else 
            {
                if(!interactRangeController.interact())
                {
                    print("noting interact");
                    isKeyPress = true;
                    hasInteracted = false;    
                }
                print("interacted");
            } 
        }
    }
    
    
    public void swipeUp()
    {
        //nothing with swipe up
        
        //anim.Play("magic");
        //BaisemaManager.instance.SetUpAll();
    }
    
    public bool isKeyPress = false;
    public enum PlayerState{Moving,Setting,Charging,Exploding};
    public PlayerState state = PlayerState.Moving;
    public void swipeDown()
    {
        if(!hasInteracted&&canUseSkill&&state == PlayerState.Moving)
        {
            isKeyPress = true;
            Charging();    
        }
        //anim.Play("explode");
        //BaisemaManager.instance.explodeAll();
        
    }
    public bool hasInteracted;
    public void release()
    {        
        
        if(!hasInteracted&&canUseSkill&&isKeyPress)
        {
            if(state == PlayerState.Charging)
            {
                Explode();
            }
            else if(state == PlayerState.Moving)
            {
                if(isMoveLocked)
                    return;
                SetBaisema();
            }
        }
        isKeyPress = false;
    }
#endregion  
    
    void SetBaisema()
    {
        state = PlayerState.Setting;
        if(HealthBarPanel.instance.spendMana(1))
        {
            print("SetBaisema");
            lockMove();
            anim.Play("magic");
            
            //voiceManager.PlaySound("setBaisema");
            BaisemaManager.instance.genBaisema(transform.position);
            Quest.broadcast("baisema_created");    
        }
        else
        {
            state = PlayerState.Moving;
        }
        
    }
    void Charging()
    {
        //voiceManager.PlaySound("charging");
        state = PlayerState.Charging;
        anim.Play("charging");    
        
    }
    void Explode()
    {
        //voiceManager.PlaySound("explode");
        state = PlayerState.Exploding;
        HealthBarPanel.instance.releaseUsingMana();
        anim.Play("explode");
        BaisemaManager.instance.explodeAll();    
        //SoundManager.instance.PlayOneShot("huh");
        
        //Quest.broadcast("exploded");
    }
    
   #region PlayerData
    public void recover(float amount)
    {
        HealthBarPanel.instance.modifyHealthIsAlive(amount);
        effectPlayer.PlayHealthGainEffect();
        
    } 
    public void damaged(float damageRaw)
    {
        Handheld.Vibrate();
        iTween.ShakePosition(Camera.main.gameObject,new Vector3(0.2f,0.2f),0.3f);
        
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1)*100);
        hurtEffect.splash(0.5f);
        if(!HealthBarPanel.instance.modifyHealthIsAlive(-damageRaw))
        {
            dead();
        }
    }
    public void dead()
    {
        anim.Play("death");
        isInputEnable = false;
        GameManager.instance.GameOver(1);
    }
    public float getAttackValue()
    {
        return data.damage;
    }
   #endregion
}
