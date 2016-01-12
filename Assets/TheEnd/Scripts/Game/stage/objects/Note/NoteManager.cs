using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NoteManager : UIPanel {


   
    public static NoteManager instance;
    public GameObject notebg;
    public Note[] notePrefabs;
	Dictionary<string,Note> noteDict = new Dictionary<string,Note>();
    
    // Use this for initialization
    protected override void Awake () {
        base.Awake();
        instance = this;
        
        //add note to dictionary
        foreach (var note in notePrefabs)
        {
            noteDict.Add(note.name,note);    
        }
        
        
	}
    Transform currentNote;
	public void showNote(string noteID)
    {
        notebg.SetActive(true);
        isDismissed = false;
        GameObject noteWrapper = Instantiate(noteDict[noteID].gameObject);
        
        RectTransform note = noteWrapper.transform.Find("note") as RectTransform;
        note.SetParent(transform);
        note.localPosition = Vector3.zero;
        note.localScale = Vector3.one;
        Player.instance.lockMove();
        currentNote = note;
        Destroy(noteWrapper);
        
        loadGraphics();
        Show();
        print("shownote");
        
        /*
        bgAnim.gameObject.SetActive(true);
        noteAnim.Rebind();
        
        noteAnim.Play("showNote");
        bgAnim.Play("showbg");
        */
        isPlaying = true;

        UIManager.instance.hideControlPanel();
    }

//    int playingIndex;
    bool isDismissed = false;
    public void dismissNote()
    {
        
        if(!isDismissed)
        {
           isDismissed = true;
           UIManager.instance.showControlPanel();
           Hide();
           print("dismiss");            
           currentNote.SendMessage("Done",null,SendMessageOptions.DontRequireReceiver);
           Player.instance.unlockMove();
           Invoke("destroyNote",0.5f);
        }
    }
    void destroyNote()
    {
        Destroy(currentNote.gameObject);
        isPlaying = false;
        eventTriggeredBy.SendMessage("Done",SendMessageOptions.DontRequireReceiver);
        eventTriggeredBy = null;
    }
    
    public ShowNoteEvent eventTriggeredBy;
}
