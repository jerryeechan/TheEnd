using UnityEngine;
using System.Collections;

public class SpawnEnemyEvent : TargetEvent {

    public EnemySpawner spawner;
    public int num;
	override protected void active()
    {
        spawner.spawn(num);
    }
}
