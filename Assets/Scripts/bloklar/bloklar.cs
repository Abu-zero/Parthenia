using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloklar : MonoBehaviour
{
    public GameObject kirmizi, mavi, sari, kirmizison, mavison, sarison, etusu, skoterpanel, karakter;
    Vector2 kirmizibaslangic, mavibaslangic, saribaslangic;
    float mesafe;
    public bool gk, gm, gs, sayac, aktif, izin;
    private Animator animator;
    private NPC npcsayac;
    public GameObject[] bloklarbitis;
    public GameObject[] bloklarbaslangis;

    void Start()
    {
        kirmizibaslangic = kirmizi.transform.position;
        mavibaslangic = mavi.transform.position;
        saribaslangic = sari.transform.position;
        animator = karakter.GetComponent<Animator>();
        izin=true;
    }

    private void Update() {
        npcsayac = GetComponent<NPC>();
        if(gk && gm && gs){
            sayac=true;
            skoterpanel.SetActive(false);
            karakter.GetComponent<move>().enabled=true;
            etusu.SetActive(false);
        }
        if(npcsayac.sayac && izin){
            GetComponent<NPC>().enabled=false;
            if(aktif)
            {
                if(!sayac){
                    skoterpanel.SetActive(true);
                    karakter.GetComponent<move>().enabled=false;
                    animator.SetFloat("hiz", Mathf.Abs(0));
                    izin=false;
                    karistir();
                }
            }
        }
    }

    public void suruklekirmizi(){
        kirmizi.transform.position = Input.mousePosition;
    }

    public void suruklemavi(){
        mavi.transform.position = Input.mousePosition;
    }

    public void suruklesari(){
        sari.transform.position = Input.mousePosition;
    }

    public void birakkirmizi(){
        mesafe = Vector3.Distance(kirmizi.transform.position, kirmizison.transform.position);
        if(mesafe<50){
            kirmizi.transform.position = kirmizison.transform.position;
            gk = true;
        }
        else{
            kirmizi.transform.position = kirmizibaslangic;
        }
    }

    public void birakmavi(){
        mesafe = Vector3.Distance(mavi.transform.position, mavison.transform.position);
        if(mesafe<50){
            mavi.transform.position = mavison.transform.position;
            gm = true;
        }
        else{
            mavi.transform.position = mavibaslangic;
        }
    }

    public void biraksari(){
        mesafe = Vector3.Distance(sari.transform.position, sarison.transform.position);
        if(mesafe<50){
            sari.transform.position = sarison.transform.position;
            gs = true;
        }
        else{
            sari.transform.position = saribaslangic;
        }
    }

    public void karistir(){
        for (int i = 0; i < bloklarbitis.Length; i++) {
            int rnd = Random.Range(0, bloklarbitis.Length);
            GameObject tempGO = bloklarbitis[rnd];
            bloklarbitis[rnd] = bloklarbitis[i];
            bloklarbitis[i] = tempGO;
        }
        for(int j=0; j<bloklarbitis.Length; j++){
            bloklarbitis[j].transform.position=new Vector2(bloklarbaslangis[j].transform.position.x, bloklarbitis[j].transform.position.y);
        }
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
