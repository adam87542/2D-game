using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyBow : MonoBehaviour
{
    Collider2D BowCollider;
    Movement DealDamage;
    int BowDamage = 20;
    private void Start()
    {
        BowCollider = GetComponent<PolygonCollider2D>();
        DealDamage = FindObjectOfType<Movement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(BowCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            DealDamage.DealDamage(BowDamage);
            Destroy(gameObject);
        }
        else if(BowCollider.IsTouchingLayers(LayerMask.GetMask("Walls")))
        {
            Destroy(gameObject);
        }
    }
}
