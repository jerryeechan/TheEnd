using UnityEngine;
using System.Collections;
using TheEnd;
public class PlayerController : Singleton<PlayerController> {

    // Use Constant.this for initialization

    public Player player;
    Vector2 lastMoveVec;
    
    #if UNITY_EDITOR
    void Update()
    {
        if(!player.isMoveLocked)
        {
            Vector2 moveVec = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
            
            if (lastMoveVec != Vector2.zero && moveVec != Vector2.zero)
            {
                move(moveVec);
            }
            lastMoveVec = moveVec;
        }
        
        if(Input.GetKeyDown("z"))
        {
            player.skillBtnTouched();
        }
        else if(Input.GetKeyUp("z"))
        {
            player.release();
        }
        else if(Input.GetKeyDown("x"))
        {
            player.swipeDown();
        }
        else if(Input.GetKeyUp("x"))
        {
            player.release();
        }
        
        if(Input.GetKeyDown("space"))
        {
            SuperUser.instance.su_speed = 2;
        }
        if(Input.GetKeyUp("space"))
        {
            SuperUser.instance.su_speed = 1;
        }
        
    }
    #endif
    
    public void move(Vector2 moveVec)
    {
        CharacterAnimationState state = CharacterAnimationState.None;
        if (moveVec.y > Constant.th)
        {
            moveVec.y = 1;
             
            state = CharacterAnimationState.Walk_Back;
        }
        else if (moveVec.y < -Constant.th)
        {
            moveVec.y = -1;
            state = CharacterAnimationState.Walk_Front;

        }
        else
            moveVec.y = 0;


        if (moveVec.x > Constant.th)
        {
            moveVec.x = 1;
            state = CharacterAnimationState.Walk_Right;
        }
        else if (moveVec.x < -Constant.th)
        {
            moveVec.x = -1;
            state = CharacterAnimationState.Walk_Left;
        }
        else
            moveVec.x = 0;


           
        moveVec = moveVec.normalized;

        
        player.PlayAnimation(state);
        player.setMoveVec(moveVec);

        //rb2d.transform.position += (Vector3)moveVec*velocity;

    }
    public bool islocked = false;
    public void lockMove()
    {
        if(!islocked)
        {
            islocked = true;
            move(Vector2.zero);
            player.lockMove();    
        }
        
    }
    public void unlockMove()
    {
        if(islocked)
        {
            islocked = false;
            player.unlockMove();    
        }
        
    }
    public void castSkill()
    {

    }
	
	
	
	
}
