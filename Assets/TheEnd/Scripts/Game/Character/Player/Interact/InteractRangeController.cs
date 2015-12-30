using UnityEngine;

public class InteractRangeController : MonoBehaviour {

    public InteractRange interactRange;
    
    
    public bool interact()
    {
        
            return interactRange.Interact();
            /*
            Enemy target = interactRange.getEnemy();
            if (target != null)
            {
                Baisema baisema = BaisemaManager.instance.genBaisema(target.transform.position);
                baisema.lockUp(target);
                anim.Play("magic");
            }
            */
            
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
	
}
