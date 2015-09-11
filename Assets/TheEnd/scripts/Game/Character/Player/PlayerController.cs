using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using TheEnd;
public class PlayerController : MonoBehaviour {
    public static PlayerController instance;

    // Use Constant.this for initialization

    public Player player;
    void Awake()
    {
        instance = this;
    }
    void Start() {
    }

    float hori = 0;
    float vert = 0;

    
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

    public void castSkill()
    {

    }
	
	
	
	
}
