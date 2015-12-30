using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PanelAnimation : MonoBehaviour {

	public void hideAllChildren()
	{
		Image [] images = GetComponentsInChildren<Image>();
		/*
		foreach(image in images)
		{
			LeanTween.alpha()
		}
		*/
	}
}
