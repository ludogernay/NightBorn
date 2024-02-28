using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerMovement : MonoBehaviour
{

    [SerializeField] private float speed =0.2f;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x-speed,transform.position.y );
    }
}
