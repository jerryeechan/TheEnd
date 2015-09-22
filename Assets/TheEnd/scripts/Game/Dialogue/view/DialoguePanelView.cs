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
        dialoguePanel.SetActive(false);
        print("hide dialogue panel");
        UIManager.instance.showAllUI();
    }
}
