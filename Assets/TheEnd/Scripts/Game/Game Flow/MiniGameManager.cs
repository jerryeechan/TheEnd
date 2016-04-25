using UnityEngine;
using System.Collections;

public class MiniGameManager : MonoBehaviour {

	public UIPanel[] gamesNeedToWarmUp;
    void Awake()
    {
        foreach(UIPanel panel in gamesNeedToWarmUp )
        {
            panel.Awake();
            panel.gameObject.SetActive(false);
        }
    }
}
