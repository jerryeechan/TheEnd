using UnityEngine;

public class ShowNoteEvent : TargetEvent {

    public string id;
	protected override void active()
    { 	
        NoteManager.instance.eventTriggeredBy = this;
        NoteManager.instance.showNote(id);
    }
}
