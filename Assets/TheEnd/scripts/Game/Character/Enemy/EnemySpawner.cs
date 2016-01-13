using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	public Enemy enemyPrefab;
    bool isEnabled = false;
    int enemyMax;
    int enemyCount = 1;
    public Enemy currentEnemy;
    void Awake()
    {
        if(currentEnemy)
            currentEnemy.spawner = this;
    }
	public void ScheduledSpawn(float delay,int num)
	{
		
	}
    public void spawn(int num)
    {
        for (int i=0;i<num;i++)
        Spawn();
    }
    public void startSpawn()
    {
        
    }
    public void stopSpawn()
    {
        SendMessage("Done");
    }
    public void recycleEnemy()
    {
        print("recycle");
        enemyCount--;
       // Invoke("Spawn",1);
    }
	void Spawn()
	{
        print("spawn");
        currentEnemy = Instantiate(enemyPrefab,transform.position,transform.rotation) as Enemy;
        currentEnemy.spawner = this;
        enemyCount++;
        if(enemyCount==enemyMax)
        {
			stopSpawn();
        }
	}
}
