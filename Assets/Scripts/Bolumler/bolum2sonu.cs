using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolum2sonu : MonoBehaviour
{
    public GameObject isik;
    public GameObject etusu;
    public bool KutuAc;
    public float beklemesure;
    private Animator animator;
    public string bolum;
    // Start is called before the first frame update
    void Start()
    {
        isik.SetActive(false);
        animator = isik.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(KutuAc==true && Input.GetKeyDown(KeyCode.E)){
            isik.SetActive(true);
            animator.SetBool("izin", true);
            StartCoroutine(bekle());
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
            KutuAc = false;
            etusu.SetActive(false);
        }
    }

    IEnumerator bekle()
    {
        yield return new WaitForSeconds(2);
        //animator.SetBool("izin", false);
        SceneManager.LoadScene(bolum);
        StopAllCoroutines();
    }
}
