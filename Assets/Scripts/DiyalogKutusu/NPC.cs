using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject DiyalogPanel;
    public Text DiyalogMetin;
    public string[] Diyalog;
    private int index;

    private int IsimIndex;
    public Text IsimKutu;
    public string[] Isim;

    public float MetinHizi;
    public bool KutuAc;
    
    public GameObject karakter;
    private Animator animator;

    bool _typing = false;

    public GameObject etusu;
    public GameObject gec;

    public bool sayac=false;
    
    void Start()
    {
        for(int i=0; i<=(Isim.Length-1);i++)
        {
            if(Isim[i]=="kullanici")
            {
                Isim[i]=PlayerPrefs.GetString("KullaniciIsim");
            }
        }
        animator = karakter.GetComponent<Animator>();
    }

    void Update()
    {
        if(sayac && KutuAc==true)
        {
            gec.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                MetinYok();
            }
        }
        if(Input.GetKeyDown(KeyCode.E) && KutuAc==true) 
        {
            if(_typing==true)
            {
                return;
            }
            else if(DiyalogMetin.text==Diyalog[index]) 
            {
                SiradakiSatir();
            }
            else
            {
                DiyalogPanel.SetActive(true);
                StopAllCoroutines();
                StartCoroutine(Typing());
                karakter.GetComponent<move>().enabled=false;
                animator.SetFloat("hiz", Mathf.Abs(0));
            }
        }
    }

    public void MetinYok()
    {
        IsimKutu.text= string.Empty;
        IsimIndex=0;
        DiyalogMetin.text=string.Empty;
        index=0;
        DiyalogPanel.SetActive(false);
        gec.SetActive(false);
        karakter.GetComponent<move>().enabled=true;
    }

    IEnumerator Typing()
    {
        _typing = true;
        DiyalogMetin.text=string.Empty;
        IsimKutu.text= string.Empty;
        foreach (char c in Isim[IsimIndex].ToCharArray())
        {
            IsimKutu.text+=c;
            yield return new WaitForSeconds(MetinHizi);
        }
        foreach (char harf in Diyalog[index].ToCharArray())
        {
            DiyalogMetin.text+=harf;
            yield return new WaitForSeconds(MetinHizi);
        }
        _typing = false;
    }

    public void SiradakiSatir()
    {
        if(index < Diyalog.Length - 1)
        {
            index++;
            if(IsimIndex<Isim.Length-1)
            {
                IsimIndex++;
            }
            DiyalogMetin.text=string.Empty;
            IsimKutu.text= string.Empty;
            StartCoroutine(Typing());
        }
        else
        {
            sayac=true;
            MetinYok();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("anakarakter"))
        {
            KutuAc = true;
            etusu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("anakarakter"))
        {
            MetinYok();
            KutuAc = false;
            etusu.SetActive(false);
        }
    }
}