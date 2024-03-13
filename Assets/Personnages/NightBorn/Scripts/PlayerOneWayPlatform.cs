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
        TilemapCollider2D platformCollider = CurrentOneWayPlatform.GetComponent<TilemapCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

}
