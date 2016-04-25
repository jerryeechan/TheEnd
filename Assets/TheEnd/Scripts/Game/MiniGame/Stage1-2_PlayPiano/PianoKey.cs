using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PianoKey : AnimatableGraphic, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite;
    public Sprite downSprite;
    public string noteName;
    
    Image image;
    AudioSource audioSource;
    PianoKeyTrack track;
    void Awake()
    {
        image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        track = GetComponent<PianoKeyTrack>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //SoundManager.instance.PlayOneShot("piano"+noteName);
        audioSource.PlayOneShot(audioSource.clip);
        //audioSource.Play(0);
        image.sprite = downSprite;
        print("key down");
        track.testNoteHit();
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        image.sprite = normalSprite;
    }
}
