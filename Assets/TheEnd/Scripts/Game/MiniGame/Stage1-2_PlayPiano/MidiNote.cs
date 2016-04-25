using UnityEngine;
using System.Collections;

public class MidiNote{
    
    public int pitch;
    public int start;
    public int duration;
    public int velocity;
    public MidiNote(int pitch,int start,int duration,int velocity)
    {
        this.pitch = pitch;
        this.start = start;
        this.duration = duration;
        this.velocity = velocity;
    }
}
