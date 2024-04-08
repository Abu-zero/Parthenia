using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bariyer : MonoBehaviour
{
    public GameObject bariyer;
    public GameObject karakter;
    public bool KutuAc;

    void Start()
    {
        bariyer.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && KutuAc==true) 
        {
            bariyer.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("anakarakter"))
        {
            KutuAc = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("anakarakter"))
        {
            KutuAc = false; 
        }
    }
}
