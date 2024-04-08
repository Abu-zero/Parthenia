using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody2D rgb;
    public float speed = 1.5f;
    public float jump = 4f;
    public float mesafe=0.1f;
    public float yon=0;
    public float sinirmesafe;
    Vector3 fark;
    Vector3 toplam;
    Vector3 velocity;
    public GameObject anakarakter;
    public GameObject kamera;
    public GameObject algilama;
    private Animator animator;
    public LayerMask lymask;
    
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        fark = transform.position - kamera.transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        kameraayar();
        ziplama();
        flip();

        if(0<Input.GetAxis("Horizontal")){
            yon=1f;
        }
        else if(0>Input.GetAxis("Horizontal")){
            yon=-1f;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(algilama.transform.position, Vector2.right * new Vector2(yon,0f), mesafe, lymask);
        
        if(hit.collider==null){
            hareket();
            Debug.DrawRay(algilama.transform.position,Vector2.right * mesafe * new Vector2 (yon,0f),Color.red);
        }
        else{
            animator.SetFloat("hiz", 0);
        }
    }

    void kameraayar()
    {
        toplam = transform.position - fark;
        kamera.transform.position = new Vector3(Mathf.Clamp(toplam.x, 3.5f, sinirmesafe), kamera.transform.position.y, kamera.transform.position.z);
    }

    void hareket()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        animator.SetFloat("hiz", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void ziplama()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            rgb.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
        }
    }

    void flip()
    {
        Vector3 characterScale = transform.localScale;

        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        anakarakter.transform.localScale = characterScale;
    }

}
