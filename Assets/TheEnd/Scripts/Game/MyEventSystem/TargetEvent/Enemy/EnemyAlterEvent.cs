using UnityEngine;
using System.Collections;

public class EnemyAlterEvent : TargetEvent {
    public EnemySpawner spawner;
    public Enemy enemy;
    public string todo;
	protected override void active()
	{
        if(!conditionValid())
            return;
		switch(todo)
        {
            case "move":
            if(enemy)
				enemy.StartToMove();
			else
            spawner.currentEnemy.StartToMove();

            break;    
        }
		
	}
}
