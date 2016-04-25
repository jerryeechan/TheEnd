using UnityEngine;
using System.Collections;
using TheEnd;
public class CharacterCondition : EventCondition {
    public MainCharacterEnum[] allowedChs;
	// Use this for initialization
	
	public override bool checkValid()
    {
        foreach(MainCharacterEnum ch in allowedChs)
        {
            if(Player.instance.current_ch == ch)
            {
                return !(true^validWhenTrue);
            }
        }
        return !(false^validWhenTrue);
    }
}
