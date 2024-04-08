using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolumbitir : MonoBehaviour
{
    private bool bitir;
    public string bolum;

    void Update()
    {
        bitir = GetComponent<NPC>().sayac;
        if(bitir==true)
        {
            SceneManager.LoadScene(bolum);
        }
    }
}
