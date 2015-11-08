using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TheEnd;
public class DialogueCharacterPanel : UIPanel {
    public Image[] characterImages;
    
    public void setCharater(int index,MainCharacterEnum character, Expression expression, AdditionMark addition)
    {
        clean();
        
        if(expression != Expression.none)
        {
            characterImages[index].sprite = DialogueCharacterManager.instance.getCharacter(character).getExpression(expression);
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
