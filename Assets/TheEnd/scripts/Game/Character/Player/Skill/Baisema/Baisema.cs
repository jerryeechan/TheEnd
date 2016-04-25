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
    Animator effectAnim;

    PolygonCollider2D bodyCollider;

    void Awake() {
        Transform effect = transform.Find("Effect");
        baisemaBase = effect.Find("base").gameObject;
        baisemaBody = effect.Find("body").gameObject;
        baisemaExplosion = effect.Find("explosion").gameObject;

        baseAnim = baisemaBase.GetComponent<Animator>();
        bodyAnim = baisemaBody.GetComponent<Animator>();
        explosionAnim = baisemaExplosion.GetComponent<Animator>();
        effectAnim = effect.GetComponent<Animator>();

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
    bool isLocked = false;
	public void lockUp(Enemy enemy)
	{
        if(!isLocked)
        {
            targetEnemy = enemy;
            targetEnemy.Locked();
            lockingTransform = targetEnemy.transform;
            //state = BaisemaState.TargetLocking;
            
            baseAnim.Play("setup");
        
            //Invoke("lockUpDone", 0.3f);
            SetUp();
            isLocked = true;    
        }
        
    }
	public void lockUpDone()
	{
        //.GetComponent<Collider2D>().isTrigger = false;
        state = BaisemaState.TargetLocked;
	}
	public void SetUp()
    {
        print("setting");
        state = BaisemaState.Setting;
        bodyAnim.Play("setup");
        Invoke("SetUpDone",0.3f);
    }
    public void SetUpDone()
    {
        print("set up done");
        state = BaisemaState.Set;
        targetEnemy.Trapped();
        bodyCollider.enabled = true;
    }
    
    public void OnTriggerEnter2D(Collider2D collider2d)
    {
        if(collider2d.tag == "Enemy")
        {
            print("Ontrigger");
            //Debug.LogError(collider2d);
            lockUp(collider2d.GetComponentInParent<Enemy>());
        }
    }
	//destroy the baiesma to attack the monster trap inside
	public void explode()
	{
        print("explode");
        
        if (state == BaisemaState.Set)
        {
            print("success");
            targetEnemy.takeDamage(Player.instance.getAttackValue());
            bodyAnim.Play("none");
            explosionAnim.Play("explode");
            baseAnim.Play("disappear");
            effectAnim.Play("disappear");
            iTween.ShakePosition(Camera.main.gameObject,new Vector3(1,1),0.2f);
        }
        else
        {
            baseAnim.Play("disappear");
            effectAnim.Play("disappear");
            print(state);
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
