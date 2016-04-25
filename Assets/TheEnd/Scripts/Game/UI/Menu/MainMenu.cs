using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenu : UIPanel {
    public UIPanel menu;
    public UIPanel cover;
    public MoviePlayer moviePlayer;
    public UIPanel skipBtn; 
    public bool isPlayingThing = false;
    public LoadPanel loadPanel;
	public void playLevel(int level)
    {
        if(!isPlaying)
        {
           isPlayingThing = true;
           hide(1);
           this.level = level;  
           //switchLevel();
           Invoke("switchLevel",1);
        }
        
    }
    int level;
    void switchLevel()
    {
       loadPanel.gameObject.SetActive(true);
       loadPanel.loadLevel(level);
       isPlayingThing = false;
    }
    
    public void playMoive()
    {
        if(!isPlayingThing)
        {
            isPlayingThing = true;
            //hide(1);
            Invoke("switchMovie",1);
        }  
    }
    
    void switchMovie()
    {
       isPlayingThing = false;
       float duration = moviePlayer.PlayMovie();
       //Invoke("playDone",duration);
    }
    void playDone()
    {
        moviePlayer.hide(1);
        show(1);
        skipBtn.hide(1);
    }
    public void skipMovie()
    {
       CancelInvoke("playDone");
       playDone();
    }
    
}
