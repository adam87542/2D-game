using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBow : MonoBehaviour
{
    [SerializeField] Transform PlayerPos;
    [SerializeField] GameObject Bow;
    [SerializeField]  Rigidbody2D Movement;
    float BowSpeed = 5f;
    public void Shoot()
    {
        GameObject Arrow = Instantiate(Bow, PlayerPos.position, Quaternion.identity) as GameObject;
        if(transform.localScale.x >0)
        {
            Arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(BowSpeed, 0f);
        }
        else
        {
            Arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-BowSpeed, 0f);
        }
    }
}

