using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TheEnd;
public class DialogueCharacterPanel : UIPanel {
    public AnimatableGraphic[] characterImages;
    
    public AnimatableGraphic memoryMask; 
    

    public void setCharater(int index,MainCharacterEnum character, Expression expression, AdditionMark addition, bool isMemory = false)
    {
        
        if(isMemory)
        {
            memoryMask.gameObject.SetActive(true);
            memoryMask.setAlpha(1);
        }
        else
        {
            memoryMask.gameObject.SetActive(false);
        }
        if(expression != Expression.none)
        {
            Debug.Log(character);
            DialogueCharacter ch = DialogueCharacterManager.instance.getCharacter(character);
            Sprite sprite = ch.getExpression(expression);
            hideOther(index);
            if(sprite!=null)
                characterImages[index].GetComponent<Image>().sprite = sprite;
            else
                characterImages[index].gameObject.SetActive(false);
            //characterImages[index].enabled = true;    
        }
        //hideOther(index);
    }
    void hideOther(int index)
    {
        for(int i=0;i<characterImages.Length;i++)
        {
            if(index!=i)
            {
//                print("hide"+i);    
                characterImages[i].gameObject.SetActive(false);
            }
            else{
                characterImages[i].gameObject.SetActive(true);
            }
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
