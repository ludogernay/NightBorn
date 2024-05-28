using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public Transform player;
    [SerializeField]private IsDead isDead;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb"))
        {
            isDead.GameOver();
            Time.timeScale = 0f;
            player.gameObject.SetActive(false);
        }
    }
}
