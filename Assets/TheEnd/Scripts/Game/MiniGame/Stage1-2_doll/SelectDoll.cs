using UnityEngine;
using System.Collections;

public class SelectDoll : Singleton<SelectDoll> {

	public Light pointLight;
    public GameObject selectedDoll;
    public Quest faceQuest;
    void Awake()
    {
        pointLight.enabled = false;
        
    }
    public void SelectTo(Transform doll)
    {
        pointLight.enabled = true;
        LeanTween.move(pointLight.gameObject,new Vector3(doll.GetPositionX(),doll.GetPositionY(),pointLight.transform.GetPositionZ()),0.5f);
        selectedDoll = doll.gameObject;
        if(doll.name == "MOMO")
        {
            faceQuest.current_state = "correct";
        }
        else
        {
            faceQuest.current_state = "wrong";
        }
    }
}
