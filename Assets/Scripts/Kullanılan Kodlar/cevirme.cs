using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cevirme : MonoBehaviour
{
    public GameObject canli;
    public GameObject karakter;
    Vector3 CharacterPosition;
    Vector3 CanliPosition;
    public bool yon=false;

    void Update()
    {
        CanliPosition = canli.transform.position;
        CharacterPosition = karakter.transform.position;
        if(CharacterPosition.x>CanliPosition.x)
        {
            yon=true;
        }
        else if(CharacterPosition.x<CanliPosition.x)
        {
            yon=false;
        }
        cevir();
    }

    public void cevir()
    { 
        if(yon)
        {
            canli.transform.rotation = Quaternion.Euler(0, 180, 0); 
        }
        else
        {
            canli.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
