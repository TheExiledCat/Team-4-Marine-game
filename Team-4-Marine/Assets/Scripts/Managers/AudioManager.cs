using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer m_AudioMixer;

    public void SetMusic (float MusicVolume)
    {
        Debug.Log(MusicVolume);
        m_AudioMixer.SetFloat("Music", MusicVolume);
    }

    public void SetSFX(float SFXVolume)
    {
        m_AudioMixer.SetFloat("SFX", SFXVolume);
    }
}
