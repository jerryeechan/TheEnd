using UnityEngine;
using System.Collections;

public class SuperUser : Singleton<SuperUser> {

	public bool isActive;
	
	public bool isSkippingDialogues;
	public float su_speed = 1;
    public bool has_all_item;
    public bool showHomeScreen;
	public bool showBlackCover;
	
    public UIPanel homeScreen;
	public UIPanel blackCover;
	public bool improvePerformance;
	public bool isReleaseVersion; 
	public GameObject[] areas;
	
	// Use this for initialization
	void Awake () {
		if(isReleaseVersion)
		{
			has_all_item = false;
			isSkippingDialogues = false;
			improvePerformance = true;
		}
		if(improvePerformance)
		{
			foreach (var area in areas)
			{
				area.SetActive(false);
			}
		}
		if(isSkippingDialogues)
			Debug.LogError("skip dialogues!!");
		su_speed = 1;
        
        if(has_all_item)
        {
            UIManager.instance.bagView.getAllItem();
        }
        if(showHomeScreen)
        {
            homeScreen.Show();
        }
		blackCover.gameObject.SetActive(true);
		blackCover.Hide();
		
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
