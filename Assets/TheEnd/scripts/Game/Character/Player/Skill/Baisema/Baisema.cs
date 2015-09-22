using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Baisema : MonoBehaviour{

    // Use this for initialization


    GameObject baisemaBase;
    GameObject baisemaBody;
    GameObject baisemaExplosion;

    Animator baseAnim;
    Animator bodyAnim;
    Animator explosionAnim;

    PolygonCollider2D bodyCollider;

    void Awake() {
		baisemaBase = transform.Find("base").gameObject;
        baisemaBody = transform.Find("body").gameObject;
        baisemaExplosion = transform.Find("explosion").gameObject;

        baseAnim = baisemaBase.GetComponent<Animator>();
        bodyAnim = baisemaBody.GetComponent<Animator>();
        explosionAnim = baisemaExplosion.GetComponent<Animator>();

        bodyCollider = GetComponent<PolygonCollider2D>();
       // bodyAnim.Stop();
        //explosionAnim.Stop();
        //baisemaObject = transform.Find("baisemaObject").gameObject;
        //perfectArea = transform.Find("perfectArea").gameObject;
        //growingBorder.SetActive(false);
        //perfectArea.SetActive(false);


    }
    void Update()
    {
        switch(state)
        {
            case BaisemaState.TargetLocked:
            case BaisemaState.TargetLocking:
                transform.position = lockingTransform.position;
                break;
        }

    }
    //set the baisema up with concrete collider
    public enum BaisemaState {None, TargetLocking, TargetLocked, Setting, Set, Exploding };
    public BaisemaState state = BaisemaState.None;

    Transform lockingTransform;
    Enemy targetEnemy;
	public void lockUp(Enemy enemy)
	{
        targetEnemy = enemy;
        targetEnemy.Locked();
        lockingTransform = targetEnemy.transform;
        state = BaisemaState.TargetLocking;
        
        baseAnim.Play("setup");
    
        Invoke("lockUpDone", 0.3f);
    }
	public void lockUpDone()
	{
        //.GetComponent<Collider2D>().isTrigger = false;
        state = BaisemaState.TargetLocked;
	}
	public void SetUp()
    {
        state = BaisemaState.Setting;
        bodyCollider.enabled = true;
        targetEnemy.Trapped();
        bodyAnim.Play("setup");
        Invoke("SetUpDone",0.6f);
    }
    public void SetUpDone()
    {
        state = BaisemaState.Set;
    }
	//destroy the baiesma to attack the monster trap inside
	public void explode()
	{
        if (state == BaisemaState.Set)
        {
            targetEnemy.takeDamage(Player.instance.getAttackValue());
            bodyAnim.Play("none");
            explosionAnim.Play("explode");
            baseAnim.Play("disappear");
        }
	}
	public bool isSet()
    {
        return state == BaisemaState.Set;
    }
	void fail()
	{
		destroy();
	}
	void destroy()
	{
		Destroy(gameObject);
	}

    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        print("point down baisema");
        if(state == BaisemaState.TargetLocked)
        {
            SetUp();

        }
        
    }
    */
}
