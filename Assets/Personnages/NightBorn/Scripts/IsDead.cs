using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsDead : MonoBehaviour
{
    public Transform player;
    void FixedUpdate()
    {
        if (player.position.x < -15.2)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi") || other.CompareTag("Projectile"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
