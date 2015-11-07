using UnityEngine;
using System.Collections.Generic;



public class InteractRange:MonoBehaviour
{
    Collider2D c2d;
    List<Enemy> enemyInRange;
    List<NoteTrigger> noteTriggerInRange;
    
    List<InteractableTrigger> interactableInRange;
    void Awake()
    {
        enemyInRange = new List<Enemy>();
        noteTriggerInRange = new List<NoteTrigger>();
        interactableInRange = new List<InteractableTrigger>();
    }
    public void changeDir(Vector3 dir)
    {
        if(dir.x==1)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(dir.x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if(dir.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if(dir.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        switch(collider2D.tag)
        {
            case "Enemy":
                Enemy enemy = collider2D.GetComponent<Enemy>();
                if(!enemy.isBaisemaLocked)
                enemyInRange.Add(enemy);
                break;
            case "Note":
                NoteTrigger noteTrigger = collider2D.GetComponent<NoteTrigger>();
                noteTriggerInRange.Add(noteTrigger);
                break;
            
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        switch (collider2D.tag)
        {
            case "Enemy":

                Enemy enemy = collider2D.GetComponent<Enemy>();
                if (enemyInRange.Contains(enemy))
                    enemyInRange.Remove(enemy);
                break;
            case "Note":
                NoteTrigger noteTrigger = collider2D.GetComponent<NoteTrigger>();
                if (noteTriggerInRange.Contains(noteTrigger))
                    noteTriggerInRange.Remove(noteTrigger);
                break;

        }
    }
    public bool isObjectTrigger()
    {
        if (noteTriggerInRange.Count > 0)
        {
            noteTriggerInRange[0].show();
            return true;
        }
        return false;
    }

    public Enemy getTarget()
    {
        if (enemyInRange.Count > 0)
        {
            float nearestDis = 100;
            int nearestIndex = 0;
            for (int i = 0; i < enemyInRange.Count; i++)
            {
                float dis = (transform.position - enemyInRange[i].transform.position).sqrMagnitude;
                if (dis < nearestDis)
                {
                    nearestDis = dis;
                    nearestIndex = i;
                }
            }
            Enemy target = enemyInRange[nearestIndex];
            enemyInRange.Remove(target);
            return target;
        }
        else
            return null;
        
    }
}