using UnityEngine;
using System.Collections;

public class PianoDieEvent : TargetEvent{

    public PianoGame pianoGame;
	protected override void active()
    {
        pianoGame.Hide();
    }
}
