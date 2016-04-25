using UnityEngine;
using System.Collections;

public class EnemyAlterEvent : TargetEvent {
    public EnemySpawner spawner;
    public string todo;
	protected override void active()
	{
        if(!conditionValid())
            return;
		switch(todo)
        {
            case "move":
            spawner.currentEnemy.StartToMove();
            break;    
        }
		
	}
}
