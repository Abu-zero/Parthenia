using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gorev_deneme : MonoBehaviour
{
    public GameObject[] gorevciler;
    public GameObject[] yangorevciler;
    int i=0;
    int k=0;
    public int j=-1;
    public string[] gorevler;
    public List<string> yenidizi;

    void Start()
    {
        yenidizi = new List<string>(gorevler);
    }

    void Update()
    {
        
        for(i=0; i<gorevciler.Length; i++)
        {
            if(gorevciler[i].GetComponent<NPC>().sayac)
            {
                j=i;
                yenidizi.Remove(gorevler[j]);
                /*if(Input.GetKeyDown(KeyCode.Tab))
                {
                    foreach (var item in yenidizi)
                    {
                        Debug.Log(item);
                    }
                    Debug.Log(gorevler[j]);
                }*/
            }
        }
        for(k=0; k<yangorevciler.Length; k++)
        {
            if(yangorevciler[k].GetComponent<baliktutma>().sayac)
            {
                j=gorevciler.Length;
                yenidizi.Remove(gorevler[j]);
            }
        }
    }
}
