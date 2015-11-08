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
            noteDict.Add(note.id,note);    
        }
        
        
	}
    Transform currentNote;
	public void showNote(string noteID)
    {
        
        GameObject noteWrapper = Instantiate(noteDict[noteID].gameObject);
        RectTransform note = noteWrapper.transform.Find("note") as RectTransform;
        note.SetParent(transform);
        note.localPosition = Vector3.zero;
        note.localScale = Vector3.one;
        
        currentNote = note;

        noteAnim.Rebind();
        
        print("shownote");
        bgAnim.gameObject.SetActive(true);
        noteAnim.Play("showNote");
        bgAnim.Play("showbg");



        UIManager.instance.hideAllUI();
    }

//    int playingIndex;
    public void dismissNote()
    {
        UIManager.instance.showAllUI();
        print("dismiss");
        noteAnim.Play("hideNote");
        bgAnim.Play("hidebg");

        currentNote.SendMessage("Done");

        Invoke("destroyNote",0.5f);
        
    }
    void destroyNote()
    {
        Destroy(currentNote.gameObject);
    }
}
