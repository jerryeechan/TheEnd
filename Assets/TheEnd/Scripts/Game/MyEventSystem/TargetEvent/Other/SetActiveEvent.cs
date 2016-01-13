using UnityEngine;
using System.Collections;
using System;

public class SetActiveEvent : TargetEvent
{

    public GameObject[] gameObjects;

    protected override void active()
    {
        foreach (var go in gameObjects)
        {
            go.SetActive(true);
        }
    }
}
