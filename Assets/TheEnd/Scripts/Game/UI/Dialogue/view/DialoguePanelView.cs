using UnityEngine;
using System.Collections;

public class DialoguePanelView : AnimatableCanvas {

    Animator anim;
    GameObject dialoguePanel;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        dialoguePanel = transform.Find("DialoguePanel").gameObject;
        anim = dialoguePanel.GetComponent<Animator>();
    }
    public bool isPlaying = false;
    public void Show()
    {
        if(isPlaying == false)
        {
            isPlaying = true;
            dialoguePanel.SetActive(true);
            anim.Play("show");
            print("show dialogue panel");
            UIManager.instance.hideAllUI();
        }
        
        
    }
    public void Hide()
    {
        Invoke("WaitHide",1);
        print("hide dialogue panel");
        anim.Play("hide");
        
        
    }
    void WaitHide()
    {
        isPlaying = false;
        dialoguePanel.SetActive(false);
        UIManager.instance.showAllUI();
    }
}
