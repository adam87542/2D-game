using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    float ScrollRate = 0.4f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, ScrollRate * Time.deltaTime));
    }
}
