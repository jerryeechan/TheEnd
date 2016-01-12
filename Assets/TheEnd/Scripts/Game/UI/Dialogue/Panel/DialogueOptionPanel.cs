using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionPanel : UIPanel {
	override protected void showDone()
    {
        base.showDone();
        Player.instance.isInputEnable = false;
    }
}
