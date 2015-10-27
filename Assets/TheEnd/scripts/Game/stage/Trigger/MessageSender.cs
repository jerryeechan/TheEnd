using UnityEngine;
using System.Collections;

public class MessageSender : MonoBehaviour {

    public string value;
	// Use this for initialization
	public void SendToParent()
    {
        transform.root.SendMessage(value);
    }
}
