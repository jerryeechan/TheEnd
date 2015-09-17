﻿using UnityEngine;
using System.Collections.Generic;



public class AttackRange:MonoBehaviour
{
    Collider2D c2d;
    List<Enemy> enemyInRange;
    void Awake()
    {
        enemyInRange = new List<Enemy>();
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
        if(collider2D.tag == "Enemy")
        {
            Enemy enemy = collider2D.GetComponent<Enemy>();
            if(!enemy.isBaisemaLocked)
            enemyInRange.Add(enemy);
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Enemy")
        {
            Enemy enemy = collider2D.GetComponent<Enemy>();
            if(enemyInRange.Contains(enemy))
                enemyInRange.Remove(enemy);
        }
    }
    public Enemy getTarget()
    {
        float nearestDis = 100;
        int nearestIndex = 0;
        for(int i=0;i<enemyInRange.Count;i++)
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
}