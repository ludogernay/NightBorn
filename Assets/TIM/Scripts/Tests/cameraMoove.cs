using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoove : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        }
    }
}
