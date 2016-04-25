using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PianoNotePlayer : MonoBehaviour {

    
    public SheetNote SheetNotePrefab;
    public Transform[] keyTransforms;
    
    public PianoKeyTrack[] tracks;
    float timeCounter = 0;
    public bool isGameStarted;
    public static float noteDropSpeed = 2;
    static float bpm = 240;
    static float secondsPerMinutes = 60;
    int nextNoteID;
    public List<SheetNote> noteList;
	// Use this for initialization
	void Awake () {
        
   
        
        tracks = new PianoKeyTrack[keyTransforms.Length];
        for(int i=0;i<keyTransforms.Length;i++)
        {
            tracks[i] = keyTransforms[i].GetComponent<PianoKeyTrack>();
        }
        
	}
    int currentTime = 2;
    void addNote(int key,int duration)
    {
        MidiNote note = new MidiNote(key,currentTime,duration,100);
        currentTime += duration;
        SheetNote sheetNote = createSheetNote(note);
        sheetNote.keyTrack = tracks[note.pitch]; 
        tracks[note.pitch].noteList.Add(sheetNote);
        noteList.Add(sheetNote);
    }
    void testNote()
    {
        for(int i=0;i<keyTransforms.Length;i++)
        {
            tracks[i].noteList = new List<SheetNote>();
        }
        noteList = new List<SheetNote>();
        currentTime = 0;
        addNote(3,2);
    }
    void prepareNote()
    {
        for(int i=0;i<keyTransforms.Length;i++)
        {
            tracks[i].noteList = new List<SheetNote>();
        }
        noteList = new List<SheetNote>();
        currentTime = 0;
        addNote(3,2);
        
        addNote(3,2);
        addNote(3,2);
        
        
        addNote(6,2);
        addNote(6,2);
        addNote(6,2);
        
        addNote(10,2);
        addNote(10,2);
        addNote(10,2);
        
        addNote(15,2);
        addNote(15,2);
        addNote(15,2);
        
        addNote(18,2);
        addNote(17,2);
        addNote(15,2);
        
        addNote(18,2);
        addNote(17,2);
        addNote(15,2);
        
        addNote(18,2);
        addNote(17,2);
        addNote(15,2);
        
        addNote(10,2);
        addNote(10,2);
        addNote(10,2);
    }
    public void StartGame()
    {
        //prepareNote();
        testNote();
        isGameStarted = true;
        timeCounter = 0;
        nextNoteID = 0;
    }
    public SheetNote createSheetNote(MidiNote note)
    {
        
        SheetNote shownote = (Instantiate(SheetNotePrefab.gameObject,Vector3.zero,Quaternion.identity) as GameObject).GetComponent<SheetNote>();
        shownote.transform.parent = transform;
        shownote.GetComponent<RectTransform>().localPosition = new Vector3(keyTransforms[note.pitch].localPosition.x,0,0);
        shownote.transform.localScale = Vector3.one;
        shownote.gameObject.SetActive(false);
        shownote.midiNote = note;
        return shownote;
    }
	void Update()
    {
        
        if(isGameStarted)
        {
           timeCounter+=Time.deltaTime;
           float noteStartTime = noteList[nextNoteID].midiNote.start*secondsPerMinutes/bpm;
           if(timeCounter >= noteStartTime)
           {
               noteList[nextNoteID].gameObject.SetActive(true);
               nextNoteID++;
               if(nextNoteID==noteList.Count)
               {
                   isGameStarted = false;
               }
           }
        }
        
    }
    
    public void fail()
    {
        isGameStarted = false;
        nextNoteID = 0;
        print("piano game fail");
        foreach(SheetNote note in noteList)
        {
            print("destroy");
            if(note)
                Destroy(note.gameObject);
        }        
    }
}
