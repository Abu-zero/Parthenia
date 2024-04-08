using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class soru_yonetici : MonoBehaviour
{
    private int dogrucevapindex;

    public GameObject dogrupanel, yanlispanel, engelpanel, sonucpanel, surebittipanel, girispanel;
    public soru_yapisi[] sorular;

    public TextMeshProUGUI sorulantext;
    public TextMeshProUGUI[] cevaplartext;

    private int sorulanindex = 0;
    private int puan;
    public string bolum;
    public GameObject[] yildizlar;

    public Slider sure_slider;
    public int verilecek_sure;
    private bool izinyok;
    private bool sure_yok;
    private bool girisatla;
    public TextMeshProUGUI suretext;
    private float sureyazi;

    void Start()
    {
        sure_slider.maxValue=verilecek_sure;
        girispanel.SetActive(true);
    }

    void Update() 
    {
        if(sure_slider.value!=sure_slider.maxValue && izinyok==false && girisatla==true)
        {
            sure_slider.value=sure_slider.value+Time.deltaTime;
            sureyazi=sureyazi-Time.deltaTime;
            suretext.text=Convert.ToString(Convert.ToInt32(sureyazi));
        }
        else if(sure_slider.value==sure_slider.maxValue && sure_yok==false && girisatla==true)
        {
            engelpanel.SetActive(true);
            surebittipanel.SetActive(true);
            sure_yok=true;
        }
    }

    private void soruhazirla()
    {
        sureyazi=sure_slider.maxValue;
        sure_slider.value=0;
        sorulantext.text = sorular[sorulanindex].sorutext;
        for(int i=0; i<cevaplartext.Length; i++)
        {
            cevaplartext[i].text = sorular[sorulanindex].cevaplar[i];
        }
        dogrucevapindex = sorular[sorulanindex].dogrucevap;
        sorulanindex++;
    }

    public void cevapbuton(int cevapindex)
    {
        izinyok=true;
        engelpanel.SetActive(true);
        if(cevapindex==dogrucevapindex)
        {
            dogrupanel.SetActive(true);
            puan++;
            Debug.Log(puan);
        }
        else
        {
            yanlispanel.SetActive(true);
        }
    }

    public void panelbuton()
    {
        izinyok=false;
        sure_yok=false;
        surebittipanel.SetActive(false);
        dogrupanel.SetActive(false);
        yanlispanel.SetActive(false);
        if(sorular.Length==sorulanindex)
        {
            if(puan>=1)
            {
                yildizlar[0].SetActive(true);
            }
            if(puan>=2)
            {
                yildizlar[1].SetActive(true);
            }
            if(puan==4)
            {
                yildizlar[2].SetActive(true);
            }
            izinyok=true;
            sure_yok=true;
            sonucpanel.SetActive(true);
            Debug.Log("bitti");
        }
        else
        {
            engelpanel.SetActive(false);
            soruhazirla();
        }
    }

    public void bolumgecis()
    {
        SceneManager.LoadScene(bolum);
    }

    public void girispanelbuton() 
    {
        girisatla=true;
        soruhazirla();
        girispanel.SetActive(false);
    }

}
