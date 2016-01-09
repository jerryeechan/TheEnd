using UnityEngine;
using System.Collections.Generic;



public class InteractRange:Singleton<InteractRange>
{
    Collider2D c2d;
    
    public List<InteractableTrigger> interactableInRange;
    void Awake()
    {
        interactableInRange = new List<InteractableTrigger>();
    }
    
    public void removeFromRange(InteractableTrigger trigger)
    {
         if (interactableInRange.Contains(trigger))
            interactableInRange.Remove(trigger);    
    }
    public enum InteractableTag{Interactable,Enemy}
    public InteractableTag targetTag; 
   
    void OnTriggerEnter2D(Collider2D collider2D)
    {        
        if(targetTag.ToString()==collider2D.tag)
        {
            addToList(collider2D);
        }
    }
    protected virtual void addToList(Collider2D collider2D)
    {
         InteractableTrigger[] interactTriggers = collider2D.GetComponents<InteractableTrigger>();
         foreach (var trigger in interactTriggers)
         {
             if(!interactableInRange.Contains(trigger))
             {
                interactableInRange.Add(trigger);        
             }
         }
         /*
                Enemy enemy = collider2D.GetComponent<Enemy>();
                if(!enemy.isBaisemaLocked)
                enemyInRange.Add(enemy);
            */
    }
    protected virtual void OnTriggerExit2D(Collider2D collider2D)
    {
        if(targetTag.ToString()==collider2D.tag)
        {
            removeFromList(collider2D);
        }
    }
    protected virtual void removeFromList(Collider2D collider2D)
    {
        
        InteractableTrigger[] interactTriggers = collider2D.GetComponents<InteractableTrigger>();
        foreach (var trigger in interactTriggers)
        {
            if (interactableInRange.Contains(trigger))
            interactableInRange.Remove(trigger);    
        }
    }
    public bool Interact()
    {
        if (interactableInRange.Count > 0)
        {
            for (int i = 0; i < interactableInRange.Count; i++)
            {
                InteractableTrigger interactable = interactableInRange[i];       
                /*
                if(interactable.requiredStates.Length!=0)
                {
                    bool isanyfail = false;
                    foreach (var state in interactable.requiredStates)
                    {
                        
                        if(PlayerState.instance.checkState(state))
                        {
                            Debug.Log(state+"success");
                            
                        }
                        else{
                            Debug.Log(state+" fail");
                            isanyfail = true;
                            break;
                        }    
                    }
                    if(isanyfail==false)
                    interactable.triggerEvent();
                    if(interactable.once)
                    {
                        interactableInRange.RemoveAt(i);
                        i--;
                    }
                }
                else{
                    */
                    interactable.triggerEvent();
                    if(interactable.once)
                    {
                        interactableInRange.RemoveAt(i);
                        i--;
                    }
                
                
            }
            return true;
        }
        
        return false;
    }

    
}