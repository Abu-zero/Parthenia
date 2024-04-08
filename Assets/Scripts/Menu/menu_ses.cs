using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_ses : MonoBehaviour
{
    public GameObject nesne;
    private AudioSource ses;

    void Start()
    {
        ses = nesne.GetComponent<AudioSource>();
    }

    public void sesi()
    {
        ses.Play();
    }
}
