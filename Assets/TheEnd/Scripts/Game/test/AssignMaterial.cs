using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class AssignMaterial : MonoBehaviour {

	public Material mToAssign;
    void Awake()
    {
        SpriteRenderer[] sprs =  GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spr in sprs)
        {
            spr.material = mToAssign;
        }
    }
}
