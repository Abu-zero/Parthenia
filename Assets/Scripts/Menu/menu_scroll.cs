using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_scroll : MonoBehaviour
{
    public Transform _camera;
    public float speed;
    public float deger;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1*speed*Time.deltaTime, 0f, 0f);

        if(_camera.position.x >= transform.position.x + deger)
        {
            transform.position=new Vector2(_camera.position.x + deger,transform.position.y);
        }
    }
}
