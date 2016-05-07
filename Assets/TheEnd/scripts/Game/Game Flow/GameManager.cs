using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {
	public BloodSplash bloodSplash;
    
    public void GameOver(float delay)
    {
        if(hasGameOver == false)
        {
           hasGameOver = true;
           Invoke("PlayGameOver",delay);
        }
    }
    
    void PlayGameOver()
    {
        bloodSplash.gameObject.SetActive(true);
        bloodSplash.splash();
        //hasGameOver = false ;   
    }
    public void Revive()
    {
        hasGameOver = false;
        ReviveSpotManager.instance.Revive();
        Player.instance.revive();
    }
	bool hasGameOver = false;
    public void quitGame()
    {
        Application.LoadLevel(0);
    }
}
