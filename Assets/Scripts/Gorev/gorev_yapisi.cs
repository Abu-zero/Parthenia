using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class gorev_yapisi : MonoBehaviour
{
    public GameObject gorev_panel;
    public Text gorev_yazi;
    public GameObject gorevciler;
    private gorev_deneme gorev;
    int a;
    
    void Start()
    {
        gorev = gorevciler.GetComponent<gorev_deneme>();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            gorev_panel.SetActive(true);
            gorev_yazi.text=string.Empty;
            gorev_yaz();
        }
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            gorev_panel.SetActive(false);
        }
        if(gorev.j!=a)
        {
            gorev_yazi.text=string.Empty;
            gorev_yaz();
            Debug.Log(a);
        }
    }

    public void gorev_yaz()
    {
        a=gorev.j;
        if(gorev.yenidizi.Count==0)
        {
            gorev_yazi.text="\n"+"Görevler Tamamlandı";
        }
        else
        {
            for(int i=0; i<gorev.yenidizi.Count; i++)
            {
                gorev_yazi.text=gorev_yazi.text+"\n"+gorev.yenidizi[i];
            }
        }
    }
}
