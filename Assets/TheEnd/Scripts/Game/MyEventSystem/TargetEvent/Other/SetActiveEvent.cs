using UnityEngine;
using System.Collections;
using System;

public class SetActiveEvent : TargetEvent
{

    public GameObject[] gameObjects;
    public bool toTrue = true;

    protected override void active()
    {
        if(!conditionValid())
            return;
        foreach (var go in gameObjects)
        {
            go.SetActive(toTrue);
        }
    }
}
