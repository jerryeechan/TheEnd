using UnityEngine;
using System.Collections;

public class UIManager : Singleton<UIManager> {

    public GameObject skillBtn;
    public GameObject virtualJoyStick;
    
    public BagView bagView;
    public DialoguePanelView dialogueView;
    public PickItemView pickItemView;
    public UIPanel menuView;
    public UIPanel blackCover;
    
    public UIPanel pausePanel;
    GameObject controllerPanel;
    void Awake()
    {
        bagView.gameObject.SetActive(true);
		controllerPanel = transform.Find("Controler_UI").gameObject;
    }
    void Start()
    {
        if(!SuperUser.instance.isActive)
        {
            menuView.Show();
            blackCover.Appear();
        }
    }
    
    public void hideControlPanel()
    {
		controllerPanel.SetActive(false);
        PlayerController.instance.lockMove(); 
        Player.instance.isInputEnable = false;
        //skillBtn.SetActive(false);
        //virtualJoyStick.SetActive(false);
    }

    public  void showControlPanel()
    {
		controllerPanel.SetActive(true);
        Player.instance.unlockMove();
        Player.instance.isInputEnable = true;
        //skillBtn.gameObject.SetActive(true);
//        virtualJoyStick.SetActive(true);
    }
    private bool isPause = false;
    
    /*
    public void pauseToggle()
    {
        if(isPause)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        isPause = ! isPause;
    }
    */
    public void pause()
    {
        pausePanel.Show();
        isPause = true;
        //Time.timeScale = 0;
    }
    public void pauseContinue()
    {
        pausePanel.Hide();
        isPause = false;
        Time.timeScale = 1;
    }
    
    public void exit()
    {
        
    }
}
