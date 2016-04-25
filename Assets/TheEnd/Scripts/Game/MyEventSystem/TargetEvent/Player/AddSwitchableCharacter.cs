using UnityEngine;
using System.Collections;
using TheEnd;
public class AddSwitchableCharacter :TargetEvent {

    public MainCharacterEnum ch;
	protected override void active()
    {
        CharacterMenu.instance.addCharacter(ch);
    }
}
