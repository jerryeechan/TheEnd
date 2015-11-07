using UnityEngine;


public class GameTrigger : MonoBehaviour {

	// Use this for initialization
	public void Awake(){
		
	}
	public bool once;
	
	public void activeTriggerEvent()
	{
		Debug.Log("active");
		GetComponent<TargetEvent>().active();
		if(once == true)
			Destroy(gameObject);
	}

   
}
