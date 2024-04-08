using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animdur : MonoBehaviour
{
    private Animator animator;
    public GameObject karakter;
    public GameObject skoter;
    public GameObject arabalar;
    Vector3 CharacterPosition;
    Vector3 SkoterPosition;
    
    void Start()
    {
        animator = arabalar.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SkoterPosition = skoter.transform.position;
        CharacterPosition = karakter.transform.position;
        if(CharacterPosition.x>SkoterPosition.x)
        {
            animator.SetBool("dur", true); 
        }
        else if(CharacterPosition.x<SkoterPosition.x)
        {
            animator.SetBool("dur", false);
        }
    }
}
