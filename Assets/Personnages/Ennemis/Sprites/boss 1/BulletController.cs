using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //LooseHP
            Destroy(gameObject);
        }
        if (other.CompareTag("Sword"))
        {
            Destroy(gameObject);
        }
    }
}
