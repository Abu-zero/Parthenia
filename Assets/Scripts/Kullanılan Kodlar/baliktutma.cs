using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Random=UnityEngine.Random;

public class baliktutma : MonoBehaviour
{
    public Slider balik_slider, gosterge_slider;
    public int verilecek_sure;
    private bool izin=true;
    public TextMeshProUGUI gorev;
    private int goster;
    public GameObject etusu;
    bool aktif;
    public GameObject karakter;
    private Animator animator;
    private float hedef;
    public GameObject baliktutpanel;
    private float deger;
    public bool sayac;
    public Vector2 gostergebaslangis;
    
    void Start()
    {
        gorev.text="";
        hedef=2.5f;
        balik_slider.maxValue=verilecek_sure;
        animator = karakter.GetComponent<Animator>();
    }

    void Update()
    {
        balik_slider.value=balik_slider.value+Time.deltaTime;
        if(aktif == true && Input.GetKeyDown(KeyCode.E) && izin==true)
        {
            karistir();
            Debug.Log(hedef);
            animator.SetBool("balik", true);
            deger=0;
            baliktutpanel.SetActive(true);
            karakter.GetComponent<move>().enabled=false;
            animator.SetFloat("hiz", Mathf.Abs(0));
            baliktut();
        }
        if(aktif == true && Input.GetKeyDown(KeyCode.F) && izin==false)
        {
            animator.SetBool("balik", false);
            deger=balik_slider.value;
        }
        if(deger>=hedef-0.5f && deger<=hedef+0.5f && izin==false)
        {
            karakter.GetComponent<move>().enabled=true;
            baliktutpanel.SetActive(false);
            goster=1;
            StartCoroutine(bekleme());
        }
        else if(balik_slider.value==balik_slider.maxValue && izin==false)
        {
            karakter.GetComponent<move>().enabled=true;
            baliktutpanel.SetActive(false);
            goster=2;
            StartCoroutine(bekleme());
        }
        else if(deger!=0 && deger!=hedef-0.5f && deger!=hedef+0.5f && izin==false)
        {
            karakter.GetComponent<move>().enabled=true;
            baliktutpanel.SetActive(false);
            goster=3;
            StartCoroutine(bekleme());
        }
    }

    private void baliktut()
    {
        goster=0;
        gorev.text="";
        balik_slider.value=0;
        izin=false;
    }

    IEnumerator bekleme()
    {
        baliktutpanel.SetActive(false);
        if(goster==1)
        {
            sayac=true;
            gorev.text="Balık Yakalandı";
        }
        else if(goster==2 || goster==3)
        {
            gorev.text="Balık Kaçtı";
        }
        yield return new WaitForSeconds(3);
        izin=true;
        gorev.text="";
        StopAllCoroutines();
    }

    public void karistir(){
        hedef = Random.Range(0.5f, balik_slider.maxValue-0.5f);
        gosterge_slider.value=hedef;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("anakarakter"))
        {
            aktif = true;
            etusu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("anakarakter"))
        {
            aktif = false;
            etusu.SetActive(false);
        }
    }
}
