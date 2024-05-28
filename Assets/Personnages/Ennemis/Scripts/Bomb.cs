using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    

    void Start()
    {
        StartCoroutine(DestroyBomb());
    }
    
    IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
