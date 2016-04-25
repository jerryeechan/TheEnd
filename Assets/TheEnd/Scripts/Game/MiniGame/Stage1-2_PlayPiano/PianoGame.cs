using UnityEngine;
using System.Collections;

public class PianoGame : UIPanel{

    int currentNoteIndex;
	// Use this for initialization
    public static PianoGame instance;
    public PianoNotePlayer notePlayer;
    public int hitNum = 0;
    override public void Awake()
    {
        base.Awake();
        instance = this;
    }
    public void StartGame()
    {
        notePlayer.StartGame();
    }
    public void testPass()
    {
        if(notePlayer.noteList.Count == hitNum)
        {
            gamePass();
        }
    }
    public void gamePass(){
        print("game pass");
        SendMessage("Done");
        Hide();
    }
    
    public void gameOver()
    {
        //play fail note...???
        print("game over");
        hitNum = 0;
        notePlayer.fail();
        GameManager.instance.GameOver(0);
        UIManager.instance.showControlPanel();
        Hide();
    }
}
