using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	Enemy enemy;
	void Awake () {
		enemy = GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		MoveTowardPlayer();
	}
	
	void MoveTowardPlayer()
	{
		Vector3 position = Player.instance.transform.position;
		enemy.move((position - enemy.transform.position).normalized);
	}

	
}
