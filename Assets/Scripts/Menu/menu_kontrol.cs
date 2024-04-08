using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class menu_kontrol : MonoBehaviour
{
    public InputField kullanici_ismi;
    private string kullanici_ad;
    public GameObject isimyokpanel;
    private char[] charsToTrim = { '*', '\'', '!', '^', '+', '%', '&', '/', '(', ')', '=', '?', '-', '_', ' ', '<', '>', '|', '"', ';', ':', '.'};
    public string yenioyun;
    private string devametoyun;
    [SerializeField] private GameObject kayityok = null;
    public GameObject girisanimasyon;
    public GameObject bilgilendirmepanel;
    public TextMeshProUGUI hikaye;
    public TextMeshProUGUI bilgi;
    public GameObject menu;
    public int sure=5;

    public void yenioyunevet()
    {
        bilgi.enabled=true;
        hikaye.enabled=true;
        kullanici_ad = kullanici_ismi.text.Trim(charsToTrim);
        if(kullanici_ad=="" || kullanici_ad==null)
        {
            kullanici_ismi.text="";
            isimyokpanel.SetActive(true);
        }
        else
        {
            Time.timeScale=1f;
            bilgi.enabled=false;
            bilgilendirmepanel.SetActive(true);
            menu.SetActive(false);
            PlayerPrefs.DeleteKey("KullaniciIsim");
            PlayerPrefs.SetString("KullaniciIsim", kullanici_ad);
            PlayerPrefs.DeleteKey("kayitlevel");
            StartCoroutine(bekleme());
        }
    }

    public void devametevet()
    {
        if(PlayerPrefs.HasKey("kayitlevel"))
        {
            devametoyun = PlayerPrefs.GetString("kayitlevel");
            SceneManager.LoadScene(devametoyun);
        }
        else
        {
            kayityok.SetActive(true);
        }
    }

    public void cikisevet()
    {
        Application.Quit();
    }

    IEnumerator bekleme()
    {
        yield return new WaitForSeconds(sure);
        hikaye.enabled=false;
        bilgi.enabled=true;
        yield return new WaitForSeconds(sure);
        bilgi.enabled=false;
        bilgilendirmepanel.SetActive(false);
        girisanimasyon.SetActive(true);
        yield return new WaitForSeconds(sure);
        SceneManager.LoadScene(yenioyun);
        StopAllCoroutines();
    }
}
