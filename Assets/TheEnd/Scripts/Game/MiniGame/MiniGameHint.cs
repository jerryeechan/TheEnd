using UnityEngine;
using System.Collections;

public class MiniGameHint : MonoBehaviour {
    public float delay;
    public float animationLength;
    Animator anim;
	// Use this for initialization
	void Awake () {
	   anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void showHint()
    {
        gameObject.SetActive(true);
        Invoke("end",animationLength);
    }
    void end()
    {
        anim.enabled = false;
        anim.StopPlayback();
        gameObject.SetActive(false);
    }
}
