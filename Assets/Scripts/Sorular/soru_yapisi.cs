using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "soru", menuName = "soru_yapisi")]
public class soru_yapisi : ScriptableObject 
{
    public string sorutext;
    public string[] cevaplar;
    public int dogrucevap;
}

   
