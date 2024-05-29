using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("laserbot"))
        {
            Debug.Log("je lai eu");
            gameObject.SetActive(false);
        }
    }
}
