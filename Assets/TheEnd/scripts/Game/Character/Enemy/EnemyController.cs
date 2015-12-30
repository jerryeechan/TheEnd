using UnityEngine;
using System.Collections;
using TheEnd;
public class EnemyController : MonoBehaviour {

	// Use this for initialization
	Enemy enemy;
    Rigidbody2D rb2d;
    void Awake () {
		enemy = GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
        if(enemy.state == Enemy.EnemyState.Movable)
		MoveTowardPlayer();
	}
	
	void MoveTowardPlayer()
	{
		Vector3 position = Player.instance.transform.position;
        Vector3 moveDir = (position - enemy.transform.position).normalized;
        move(moveDir);
        
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
            enemy.faceRight();
        }
        else if (moveVec.x < -Constant.th)
        {
            animState = CharacterAnimationState.Walk_Left;
            enemy.faceLeft();
        }
        enemy.PlayAnimation(animState);
        enemy.setMoveVec(moveVec);

    }
	
}
