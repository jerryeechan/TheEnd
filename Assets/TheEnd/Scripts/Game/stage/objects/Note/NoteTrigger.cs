using UnityEngine;

public class NoteTrigger : MonoBehaviour {

    public string id;
	public void show()
    { 	
        NoteManager.instance.showNote(id);
    }
}
