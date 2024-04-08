using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    public float speed = 0.05f;
    Vector2 tekrar;
    // Update is called once per frame
    void Update()
    {
        tekrar = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = tekrar;
    }
}
