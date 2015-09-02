using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {


	
	// Update is called once per frame
	
	int flag = 0;
	
	float[] color = new float[3];
	
	float[] dis = new float[3];
	int[] counter = new int[3];
	
	void Awake()
	{
		for(int i=0;i<3;i++)
		color[i] = 0.2f;
	}
	void Update () {
		
		for(int i=0;i<3;i++)
		{
			if(counter[i]==0)
				rand(i);
			else
			{
				color[i]+=dis[i];
				if(color[i] >=1)
					color[i] = 1;
				else if(color[i]<=0)
					color[i] = 0;
				counter[i]++;
				if(counter[i]>=50)
					counter[i] = 0;
			}
		}
		
		
		
		
		Camera.main.backgroundColor = new Color(color[0],color[1],color[2]);
	}
	
	
	
	void rand(int i)
	{
		if(Random.Range(0,2)==0)
		{
			dis[i]=0.0005f;
		}
		else 
		{
			dis[i] = -0.0005f;
		}
		counter[i]++;
	}
	
	/*
	switch(flag)
		{
			case 0:
			r+=0.001f;
			if(r>=0.4f)
			flag = 1;
			break;
			
			case 1:
			g+=0.001f;
			if(g>=0.4f)
			flag = 2;
			break;
			
			case 2:
			b+=0.001f;
			if(b>=0.4f)
			flag = 3;
			break;
		}*/
}
