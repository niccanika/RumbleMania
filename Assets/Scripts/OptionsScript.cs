using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    public Slider Music;
    public Slider SFX;
    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;

    void Start()
    {
        MusicMixer.SetFloat("MusicLevel", SaveScript.MusicVolume);
        SFXMixer.SetFloat("SFXicLevel", SaveScript.SFXVolume);
    }

    public void MusicVolume()
    {
        MusicMixer.SetFloat("MusicLevel", Music.value);
        SaveScript.MusicVolume = Music.value;
    }
    public void SFXVolume()
    {
       SFXMixer.SetFloat("SFXicLevel", SFX.value);
       SaveScript.SFXVolume = SFX.value;
    }
}
