using UnityEngine;
using System.Collections.Generic;

public class PianoKeyTrack : MonoBehaviour {
    public List<SheetNote> noteList;
    
	public int keyIndex;
    public int testNoteHit()
    {
        if(noteList.Count>0)
        return noteList[0].testHit();
        else
        return -1;
    }
    public void noteMiss(SheetNote note)
    {
        noteList.Remove(note);
    }
}

