using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SheetNote : MonoBehaviour {
    
    public PianoKeyTrack keyTrack;
    public MidiNote midiNote;
	// Use this for initialization
    RectTransform rectT;
    public Image halo;
	void Start () {
	 rectT = GetComponent<RectTransform>();
     
	}
	
    bool isFalling = true;
	// Update is called once per frame
	void Update () {
        if(isFalling)
        {
	     
         rectT.SetPositionY(rectT.GetPositionY()-PianoNotePlayer.noteDropSpeed);
         //perfect -660
         if(rectT.localPosition.y <= -700)
         {
             fail();
         }
        }
	}
    
    public int testHit()
    {
        float y = rectT.localPosition.y;
        print("test piano hit");
        if(y <= -580&&y>=-680)
         {
             
             successHit();
             return 1;
         }
         else
         {
             failTiming();
         }
        return 0;
    }
    void successHit()
    {
        print("success piano hit");
        halo.enabled = true;
        halo.CrossFadeAlpha(0,1,true);
        LeanTween.scale(halo.gameObject,Vector3.one*3,1f);
        
        remove();
        PianoGame.instance.hitNum++;
        PianoGame.instance.testPass();
    }
    void fail()
    {
        remove();
        PianoGame.instance.gameOver();
    }
    void failTiming()
    {
        fail();
    }
    void remove()
    {
        print("remove");
        isFalling = false;
        keyTrack.noteMiss(this);
        GetComponent<Image>().CrossFadeAlpha(0,1,false);
        Destroy(gameObject,1);
    }
    
}
