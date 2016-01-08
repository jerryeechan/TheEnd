using UnityEngine;
using System.Collections;

public class UIManager : Singleton<UIManager> {

    public GameObject skillBtn;
    public GameObject virtualJoyStick;
    
    public BagView bagView;
    public DialoguePanelView dialogueView;
    public void hideAllUI()
    {
        skillBtn.SetActive(false);
        virtualJoyStick.SetActive(false);
    }

    public  void showAllUI()
    {
        skillBtn.gameObject.SetActive(true);
        virtualJoyStick.SetActive(true);
    }
}
