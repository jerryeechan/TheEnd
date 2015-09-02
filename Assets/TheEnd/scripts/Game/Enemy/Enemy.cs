using UnityEngine;
using System.Collections;

public class Enemy:MonoBehaviour{


	public Rigidbody2D rb2d;
	Collider2D c2d;
	public EnemyData enemyData;
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		c2d = GetComponent<BoxCollider2D>();
	}
	
	
	enum EnemyState{Movable,Trapped,Died};
	EnemyState state = EnemyState.Movable;
	void OnTriggerEnter2D(Collider2D collider2D)
	{
		if(collider2D.tag == "Baisema")
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
		if(collision2D.collider.tag == "Baisema")
		{
			//c2d.isTrigger = true;
		}
	}
	
	public void move(Vector3 dir)
	{
		if(state == EnemyState.Movable)
		rb2d.velocity = dir * enemyData.moveVelocity;
	}
	
	public void takeDamage(float damage)
	{
		enemyData.health -= damage;
		if (enemyData.health<=0)
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
