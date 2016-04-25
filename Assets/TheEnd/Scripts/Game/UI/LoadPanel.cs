using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadPanel :UIPanel{

	public AnimatableGraphic[] levelcovers;
	public void loadLevel(int level)
	{
		print(level);
		//GetComponent<AnimatableGraphic>().show(1);		
		levelcovers[level-1].show(1);
		loadImage.transform.parent.GetComponent<AnimatableGraphic>().show(1);
		loadImage.GetComponent<AnimatableGraphic>().show(1);
		StartCoroutine (DisplayLoadingScreen(level));
	}
	public Image loadImage;
	IEnumerator DisplayLoadingScreen (int level){
	    AsyncOperation async = Application.LoadLevelAsync(level);
	    while (!async.isDone) {

	        //loadText.text = (async.progress * 100).ToString() + "%";////(4)
				loadImage.fillAmount = async.progress;
	        yield return null;
	    }
	}
}
