using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	public Enemy enemyPrefab;
    int enemyMax;
    int enemyCount = 1;
    public Enemy currentEnemy;
    void Awake()
    {
        if(currentEnemy)
            currentEnemy.spawner = this;
    }
	void ScheduledSpawn(float delay,int num)
	{
		
	}
    public void recycleEnemy()
    {
        print("recycle");
        enemyCount--;
        Invoke("Spawn",1);
    }
	void Spawn()
	{
        print("spawn");
        currentEnemy = Instantiate(enemyPrefab,transform.position,transform.rotation) as Enemy;
        currentEnemy.spawner = this;
        enemyCount++;
	}
}
