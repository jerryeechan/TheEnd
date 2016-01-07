using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TheEnd;
public class DialogueCharacterPanel : UIPanel {
    public Image[] characterImages;
    public Image memoryMask; 
    
    public void setCharater(int index,MainCharacterEnum character, Expression expression, AdditionMark addition, bool isMemory = false)
    {
        clean();
        if(isMemory)
        {
            memoryMask.gameObject.SetActive(true);
        }
        else
        {
            memoryMask.gameObject.SetActive(false);
        }
        if(expression != Expression.none)
        {
            Debug.Log(character);
            DialogueCharacter ch = DialogueCharacterManager.instance.getCharacter(character);
            Debug.Log(ch);
            Sprite sprite = ch.getExpression(expression);
            characterImages[index].sprite = sprite;
            characterImages[index].enabled = true;    
        }
    }
    public void clean()
    {
        foreach (var chImage in characterImages)
        {
            chImage.enabled = false;
        }
    }
	
}
