using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using System.Collections.Generic;
public class CameraEvent : TargetEvent {
	
	public List<Transform> nodes;
	public List<float> durations;
	public List<float> pause;
	
	
	override protected void active()
	{
		cameraObj = Camera.main.GetComponent<Camera2DFollow>();
		cameraObj.enabled = false;
		nodes.Insert(0,Player.instance.transform);
		durations.Insert(0,0.5f);
		pause.Insert(0,0);
		
		nodes.Add(Player.instance.transform);
		durations.Add(1);
		pause.Add(0);
		moveCamera();
	}
	private Camera2DFollow cameraObj;
	private int current;
	void moveCamera()
	{
		if(current == nodes.Count)
		{
			//end
			cameraObj.enabled = true;
			return;
		}
		Vector3 position = nodes[current].position;
		position.z = -10;
		LeanTween.move(cameraObj.gameObject,position,durations[current]);
		
		Invoke("moveCamera",durations[current]+pause[current]);
		current++;
		
	}
}
