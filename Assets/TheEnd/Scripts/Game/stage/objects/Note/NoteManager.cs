using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NoteManager : MonoBehaviour {

   Animator noteAnim;
   public Animator bgAnim;
    public static NoteManager instance;
    public Note[] notePrefabs;
	Dictionary<string,Note> noteDict = new Dictionary<string,Note>();
    // Use this for initialization
    void Awake () {
        noteAnim = GetComponent<Animator>();
        instance = this;
        
        //add note to dictionary
        foreach (var note in notePrefabs)
        {
            noteDict.Add(note.name,note);    
        }
        
        
	}
    Transform currentNote;
    public bool isPlaying = false;
	public void showNote(string noteID)
    {
        isDismissed = false;
        GameObject noteWrapper = Instantiate(noteDict[noteID].gameObject);
        
        RectTransform note = noteWrapper.transform.Find("note") as RectTransform;
        note.SetParent(transform);
        note.localPosition = Vector3.zero;
        note.localScale = Vector3.one;
        PlayerController.instance.lockMove();
        currentNote = note;
        Destroy(noteWrapper);
        
        print("shownote");
        bgAnim.gameObject.SetActive(true);
        noteAnim.Rebind();
        
        noteAnim.Play("showNote");
        bgAnim.Play("showbg");
        
        isPlaying = true;

        UIManager.instance.hideAllUI();
    }

//    int playingIndex;
    bool isDismissed = false;
    public void dismissNote()
    {
        
        if(!isDismissed)
        {
           isDismissed = true;
           UIManager.instance.showAllUI();
            print("dismiss");
            noteAnim.Play("hideNote");
            bgAnim.Play("hidebg");
    
            currentNote.SendMessage("Done");
            PlayerController.instance.unlockMove();
            Invoke("destroyNote",0.5f);
        }
        
        
    }
    void destroyNote()
    {
        Destroy(currentNote.gameObject);
        isPlaying = false;
        eventTriggeredBy.SendMessage("Done",SendMessageOptions.DontRequireReceiver);
    }
    
    public ShowNoteEvent eventTriggeredBy;
}
