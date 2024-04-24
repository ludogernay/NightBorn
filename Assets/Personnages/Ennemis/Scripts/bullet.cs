using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //tue le joueur
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(DestroyBomb());
    }

    IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
