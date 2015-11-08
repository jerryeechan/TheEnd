using UnityEngine;
using System.Collections.Generic;
public class DialogueInvestigateImageManager : MonoBehaviour {

	public List<Sprite> sprites;
	Dictionary<string,Sprite> dict = new Dictionary<string,Sprite>();
	void Awake()
	{
		foreach (var sprite in sprites)
		{
			if(sprite != null)
			{
				Debug.Log(sprite.name);
				dict.Add(sprite.name,sprite);
			}
		}
	}
	// Use this for initialization
	public Sprite getImage(string name)
	{
		if(dict.ContainsKey(name))
		return dict[name];
		else
		{
			Debug.LogError("no image: "+name);
			return null;
		}
	}
}
