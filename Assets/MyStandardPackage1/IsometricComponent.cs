using UnityEngine;
using System.Collections;

public class IsometricComponent : MonoBehaviour {

    SpriteRenderer _spr;
	// Use this for initialization
	public int localorder;
    void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();
    }
    public SpriteRenderer spr()
    {
        return _spr;
    }
}
