using UnityEngine;
using System.Collections;

public class AttackRange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
    /*
	public Enemy getEnemy()
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
    */
}
