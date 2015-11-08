using UnityEngine;
using System.Collections.Generic;



public class InteractRange:MonoBehaviour
{
    Collider2D c2d;
    
    List<InteractableTrigger> interactableInRange;
    void Awake()
    {
        interactableInRange = new List<InteractableTrigger>();
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
         InteractableTrigger interact = collider2D.GetComponent<InteractableTrigger>();
         interactableInRange.Add(interact);
         
         /*
                Enemy enemy = collider2D.GetComponent<Enemy>();
                if(!enemy.isBaisemaLocked)
                enemyInRange.Add(enemy);
            */
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if(targetTag.ToString()==collider2D.tag)
        {
            removeFromList(collider2D);
        }
    }
    protected virtual void removeFromList(Collider2D collider2D)
    {
        InteractableTrigger interact = collider2D.GetComponent<InteractableTrigger>();
        if (interactableInRange.Contains(interact))
            interactableInRange.Remove(interact);
    }
    public bool Interact()
    {
        if (interactableInRange.Count > 0)
        {
            interactableInRange[0].activeTriggerEvent();
            return true;
        }
        return false;
    }

    
}