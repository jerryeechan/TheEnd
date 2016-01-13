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
    void Awake()
    {
        bagView.gameObject.SetActive(true);
    }
    void Start()
    {
        
        menuView.Show();
        blackCover.Appear();
    }
    public void hideControlPanel()
    {
        skillBtn.SetActive(false);
        virtualJoyStick.SetActive(false);
    }

    public  void showControlPanel()
    {
        skillBtn.gameObject.SetActive(true);
        virtualJoyStick.SetActive(true);
    }
}
