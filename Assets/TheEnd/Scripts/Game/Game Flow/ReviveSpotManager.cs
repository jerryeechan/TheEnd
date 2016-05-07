using UnityEngine;
using System.Collections;

public class ReviveSpotManager : Singleton<ReviveSpotManager> {
    public Transform[] spots;
    public Transform lastSpot;
    void Awake()
    {
        lastSpot = spots[0];
    }
    public void Revive()
    {
        Player.instance.transform.position = lastSpot.position;
        
    }
}
