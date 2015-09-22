using UnityEngine;
using System.Collections;

public class NoteManager : MonoBehaviour {

   Animator noteAnim;
   public Animator bgAnim;
    public static NoteManager instance;

    public GameObject[] notePrefabs;
    // Use this for initialization
    void Awake () {
        noteAnim = GetComponent<Animator>();
        print(noteAnim);
        instance = this;
	}

    Transform currentNote;
	public void showNote(int index)
    {
        GameObject noteWrapper = Instantiate(notePrefabs[index-1]);
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
        playingIndex = index;


        UIManager.instance.hideAllUI();
    }

    int playingIndex;
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
