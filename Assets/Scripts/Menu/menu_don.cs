using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_don : MonoBehaviour
{
    public GameObject durpaneli;
    public GameObject[] kapatılıcaklar;
    int i;
    
    void Start() 
    {
        Time.timeScale=1f;
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            duraklat(); 
        }
    }

    public void duraklat()
    {
        for(i=0; i<kapatılıcaklar.Length;i++)
        {
            kapatılıcaklar[i].GetComponent<NPC>().enabled=false;  
        }
        durpaneli.SetActive(true);
        Time.timeScale=0f;
    }

    public void devamettir()
    {
        for(i=0; i<kapatılıcaklar.Length;i++)
        {
            kapatılıcaklar[i].GetComponent<NPC>().enabled=true;  
        }
        durpaneli.SetActive(false);
        Time.timeScale=1f;
    }

    public void menudon()
    {
        SceneManager.LoadScene("Menu");
    }

}
