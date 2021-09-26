using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMovement : MonoBehaviour
{
    float speed = 2f;
    Rigidbody2D myrigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Facing())
        {
            myrigidbody2D.velocity = new Vector2(speed, 0f);
        }
        else
        {
            myrigidbody2D.velocity = new Vector2(-speed, 0f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Math.Sign(myrigidbody2D.velocity.x)) , 1f);
    }
    private bool Facing() { return transform.localScale.x > 0; }
}
