using UnityEngine;
using System.Collections;
using TheEnd;
public class EnemyController : MonoBehaviour {

	// Use this for initialization
	Enemy enemy;
    Rigidbody2D rb2d;
    public bool isMoving;
    public bool isXFlip = true;
    void Awake () {
		enemy = GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
        if(enemy.state == Enemy.EnemyState.Movable)
		MoveTowardPlayer();
	}
	static LayerMask defaultLayer = LayerMask.GetMask("Default");
	void MoveTowardPlayer()
	{

//        RaycastHit2D ray = Physics2D.Raycast(enemy.transform.position,Player.instance.transform.position-enemy.transform.position,10,defaultLayer);

        
     //   if(ray&&ray.collider.tag=="Player")
       // {

            Vector3 position = Player.instance.transform.position;
            Vector3 moveDir = (position - enemy.transform.position).normalized;
            move(moveDir);
        //}
        
	}
    void move(Vector2 moveVec)
    {
        CharacterAnimationState animState = CharacterAnimationState.None;
        if (moveVec.y > Constant.th)
        {
            animState = CharacterAnimationState.Walk_Back;
        }
        else if (moveVec.y < -Constant.th)
        {
            animState = CharacterAnimationState.Walk_Front;
        }


        if (moveVec.x > Constant.th)
        {
            animState = CharacterAnimationState.Walk_Right;
            if(isXFlip)
            enemy.faceRight();
        }
        else if (moveVec.x < -Constant.th)
        {
            animState = CharacterAnimationState.Walk_Left;
            if(isXFlip)
            enemy.faceLeft();
        }
        enemy.PlayAnimation(animState);
        enemy.setMoveVec(moveVec);

    }
	
}
