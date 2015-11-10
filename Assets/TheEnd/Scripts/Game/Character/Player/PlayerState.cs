using UnityEngine;
using System.Collections.Generic;
public class PlayerState : Singleton<PlayerState>{
	public List<string> eventStateList;
	
	public bool checkState(string state)
    {
        return eventStateList.Contains(state);
    }
    
}