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
	public void ShowOption(QuestItem item1, QuestItem item2)
	{
		image1.sprite = item1.sprite;
		
		button2.gameObject.SetActive(true);
		image2.sprite = item2.sprite;
	}
	public void ShowOption(Item item)
	{
		image1.sprite = item.sprite;
		button2.gameObject.SetActive(false);
		
	}
	void Show()
	{
		DialogueManager.instance.PlayDialogue(new Dialogue());
	}
}
