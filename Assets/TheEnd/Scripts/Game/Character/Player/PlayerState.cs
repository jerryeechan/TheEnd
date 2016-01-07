using UnityEngine;
using System.Collections.Generic;

public enum State{
	no_faucet,has_faucet,
	no_keycard,has_keycard,
	no_key,has_key,
	no_palette_chalk,has_palette,has_chalk, 
	warehouse_locked,warehouse_unlocked,
	no_knife,has_knife,
	not_seen_sink, has_seen_sink, 
	wet_palette,
	plaster_moved,
	no_palette,
	plaster_colored
	
}
public class PlayerState : Singleton<PlayerState>{
	public List<State> eventStateList;
	
	public bool checkState(State state)
    {
        return eventStateList.Contains(state);	
    }
    
}