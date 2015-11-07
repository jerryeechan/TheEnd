using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T _instance;
	
	/**
      Returns the instance of this singleton.
   */
	void Awake()
	{
		if(_instance==null||_instance==this)
		{
			
			_instance = (T) FindObjectOfType(typeof(T));
			
			if (_instance == null)
			{
				Debug.LogError("An instance of " + typeof(T) + 
				               " is needed in the scene, but there is none.");
			}
		}
		else
		{
			Debug.Log("Destroy the second singleton");
			Destroy(gameObject);
		}
	}
	public static T instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = (T) FindObjectOfType(typeof(T));
				
				if (_instance == null)
				{
					Debug.LogError("An instance of " + typeof(T) + 
					               " is needed in the scene, but there is none.");
				}
			}
			
			return _instance;
		}
	}
}

