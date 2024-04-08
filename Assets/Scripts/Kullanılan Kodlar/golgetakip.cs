using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golgetakip : MonoBehaviour
{
    public GameObject karakter;
    public GameObject golge;
    Vector3 fark;
    Vector3 toplam;
    Rigidbody2D rgb;
    // Start is called before the first frame update
    void Start()
    {
        rgb = karakter.GetComponent<Rigidbody2D>();
        fark = karakter.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        toplam = karakter.transform.position - fark;
        golge.transform.position = new Vector3 (toplam.x, golge.transform.position.y, golge.transform.position.z);
        /*if(Mathf.Approximately(rgb.velocity.y, 0)){
            golge.transform.position = new Vector3 (toplam.x, toplam.y+0.05f, golge.transform.position.z);
        }*/
        if(rgb.velocity.y>=0 && rgb.velocity.y<=0.01){
            golge.transform.position = new Vector3 (toplam.x, toplam.y+0.05f, golge.transform.position.z);
        }
    }
}
