using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BaisemaManager : MonoBehaviour {

	List<Baisema> baisemaList;
	public static BaisemaManager instance;
	void Awake()
	{
		baisemaList = new List<Baisema>();
		instance = this;
	}
	public void addBaisema(Baisema b)
	{
		baisemaList.Add(b);
	}
	public void explodeAll()
	{
		
		foreach(Baisema b in baisemaList)
		{
			b.explode();
		}
		baisemaList.Clear();
		
	}
}
