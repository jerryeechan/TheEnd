using UnityEngine;
using System.Collections;

public class MessageSender : MonoBehaviour {

	// Use this for initialization
	void SendParent(string methodName)
	{
		transform.parent.SendMessage(methodName,SendMessageOptions.DontRequireReceiver);
	}
}
