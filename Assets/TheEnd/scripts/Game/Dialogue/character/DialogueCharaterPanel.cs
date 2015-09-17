using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogueCharaterPanel : MonoBehaviour {
    private Image characterImage;

    void Awake()
    {
        characterImage = GetComponent<Image>();
    }
    public void setCharater(string character,string expression)
    {

    }
	
}
