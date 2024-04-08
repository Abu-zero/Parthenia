using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gorev_verilenler : MonoBehaviour
{
    public GameObject gorevciler1,gorevciler2,gorevciler3,gorevciler4,gorevciler5;
    public GameObject gorevyapisi;
    private gorev_yapisi gorevdizi;
    private NPC gorevci1,gorevci2,gorevci3,gorevci4,gorevci5;
    public int j=-1;
    public bool gorev1,gorev2,gorev3,gorev4,gorev5;
    public string[] gorevler;
    public List<string> yenidizi;

    void Start()
    {
        gorevci1 = gorevciler1.GetComponent<NPC>();
        gorevci2 = gorevciler2.GetComponent<NPC>();
        gorevci3 = gorevciler3.GetComponent<NPC>();
        gorevci4 = gorevciler4.GetComponent<NPC>();
        gorevci5 = gorevciler5.GetComponent<NPC>();
        //gorevdizi = gorevyapisi.GetComponent<gorev_yapisi>();
        yenidizi = new List<string>(gorevler);
    }

    void Update()
    {
        if(gorev1==false)
        {
            if(gorevci1.sayac)
            {
                j=0;
                gorev1=true;
                yenidizi.Remove(gorevler[j]);
                foreach (var item in yenidizi)
                {
                    Debug.Log(item);
                }
                Debug.Log(gorevler[j]);
            }
        }
        if(gorev2==false)
        {
            if(gorevci2.sayac)
            {
                j=1;
                gorev2=true;
                yenidizi.Remove(gorevler[j]);
                foreach (var item in yenidizi)
                {
                    Debug.Log(item);
                }
                //yenidizi.RemoveAt(j);
            }
        }
        if(gorev3==false)
        {
            if(gorevci3.sayac)
            {
                j=2;
                gorev3=true;
                yenidizi.Remove(gorevler[j]);
                foreach (var item in yenidizi)
                {
                    Debug.Log(item);
                }
                Debug.Log(j);
            }
        }
        if(gorev4==false)
        {
            if(gorevci4.sayac)
            {
                j=3;
                gorev4=true;
                yenidizi.Remove(gorevler[j]);
                foreach (var item in yenidizi)
                {
                    Debug.Log(item);
                }
                Debug.Log(j);
            }
        }
        if(gorev5==false)
        {
            if(gorevci5.sayac)
            {
                j=4;
                gorev5=true;
                yenidizi.Remove(gorevler[j]);
                foreach (var item in yenidizi)
                {
                    Debug.Log(item);
                }
                Debug.Log(j);
            }
        }
    }
}
