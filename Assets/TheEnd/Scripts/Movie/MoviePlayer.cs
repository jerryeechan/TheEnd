using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MoviePlayer : UIPanel {
    /*
    #if UNITY_EDITOR_OSX
        public MovieTexture movieTexture;
    
        public float PlayMovie()
        {
            
            Show();
            GetComponent<Image>().material.mainTexture = movieTexture;
            movieTexture.Play();
            return movieTexture.duration;
                //Handheld.PlayFullScreenMovie ("start.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
            //GetComponent<Renderer>().material.mainTexture = movTexture;
        }
    #endif
    */
    #if UNITY_ANDROID
    public float PlayMovie()
    {
        Handheld.PlayFullScreenMovie ("start.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        return -1;
    }
    #endif
	
}
