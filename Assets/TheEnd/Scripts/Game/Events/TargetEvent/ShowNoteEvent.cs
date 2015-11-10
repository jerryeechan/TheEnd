using UnityEngine;

public class ShowNoteEvent : TargetEvent {

    public string id;
	protected override void active()
    { 	
        NoteManager.instance.showNote(id);
		NoteManager.instance.eventTriggeredBy = this;
    }
}
