using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyun_scroll : MonoBehaviour
{
    public Transform _camera;
    public Transform gok;
    public float speed;
    private float deger;
    // Update is called once per frame
    void Update()
    {
        deger=GetComponent<SpriteRenderer>().bounds.size.x;
        transform.Translate(-1*speed*Time.deltaTime, 0f, 0f);

        if(_camera.position.x >= transform.position.x + deger)
        {
            transform.position=new Vector2(_camera.position.x + deger,transform.position.y);
        }
        else if(_camera.position.x <= transform.position.x - deger)
        {
            transform.position=new Vector2(_camera.position.x - deger,transform.position.y);
        }
    }
}
