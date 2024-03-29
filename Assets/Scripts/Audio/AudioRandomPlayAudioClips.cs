using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    public List<AudioClip> clipList;
    public List<AudioSource> audioSourceList;

    private int _index = 0;
   
    public void PlayRandom()
    {
        if(_index >= audioSourceList.Count) { _index = 0; }

        var audioSource = audioSourceList[_index];
        audioSource.clip = clipList[Random.Range(0, clipList.Count)];
        audioSource.Play();

        _index++;
    }
}
