using UnityEngine;
using System.Collections;

public class DialoguePanelView : MonoBehaviour {

    Animator anim;
    GameObject dialoguePanel;
    // Use this for initialization
    void Awake()
    {
        dialoguePanel = transform.Find("DialoguePanel").gameObject;
    }
    public void Show()
    {
        dialoguePanel.SetActive(true);
        print("show dialogue panel");
        UIManager.instance.hideAllUI();
    }
    public void Hide()
    {
        Invoke("WaitHide",1);
        print("hide dialogue panel");
        
    }
    void WaitHide()
    {
        dialoguePanel.SetActive(false);
        UIManager.instance.showAllUI();
    }
}
