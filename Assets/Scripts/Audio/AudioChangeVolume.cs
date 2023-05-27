using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer group;
    public string floatParam = "VolumeSFX";

    public void ChangeValue(float f)
    {
        group.SetFloat(floatParam, f);
    }
}
