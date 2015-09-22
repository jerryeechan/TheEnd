using UnityEngine;
using System.Collections;

public class NoteTrigger : MonoBehaviour {

    public int index;
	public void show()
    {
        NoteManager.instance.showNote(index);
    }
}
