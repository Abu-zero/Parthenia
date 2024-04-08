using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class bolumscript : MonoBehaviour
{
    public string bolum;
    public AudioMixer mixer;

    void Start()
    {
        PlayerPrefs.SetString("kayitlevel", bolum);
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("musikses"))*20);
    }
}
