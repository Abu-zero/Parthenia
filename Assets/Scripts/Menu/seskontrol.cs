using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class seskontrol : MonoBehaviour
{
    public AudioMixer mixer;

    void Start() 
    {
        GetComponent<Slider>().value=PlayerPrefs.GetFloat("musikses");
    }

    public void sesayarla(float sliderdeger)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderdeger)*20);
        PlayerPrefs.SetFloat("musikses", sliderdeger);
    }
}
