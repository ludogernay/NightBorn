using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private GameObject CurrentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            if (CurrentOneWayPlatform != null) 
            {
                Debug.Log("passe à travers");
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            CurrentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            CurrentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        Rigidbody2D platformCollider = CurrentOneWayPlatform.GetComponent<Rigidbody2D>();

        //Physics2D.IgnoreCollision(playerCollider, platformCollider);
        platformCollider.simulated = false;
        yield return new WaitForSeconds(0.25f);
        platformCollider.simulated = true;
        //Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

}
