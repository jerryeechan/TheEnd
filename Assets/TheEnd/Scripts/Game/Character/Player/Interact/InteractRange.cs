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
         interactableInRange.AddRange(interactTriggers);
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
            foreach (var interactable in interactableInRange)
            {
                if(interactable.requiredState != "none")
                {

                    if(PlayerState.instance.checkState(interactable.requiredState))
                    {
                        Debug.Log(interactable.requiredState+" success");
                        interactable.triggerEvent();
                    }
                    else{
                        Debug.Log(interactable.requiredState+" fail");
                    }
                }
                else{
                    interactable.triggerEvent();
                }
            }
            return true;
        }
        return false;
    }

    
}