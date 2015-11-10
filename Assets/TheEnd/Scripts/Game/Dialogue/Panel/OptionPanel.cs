using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : Singleton<OptionPanel> {

	Image image1;
	Image image2;
	
	public Button button1;
	public Button button2;
	
	// Use this for initialization
	void Awake () {
		image1 = button1.GetComponentInChildren<Image>();
		image2 = button2.GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void SetOption()
	{
		
	}
}
