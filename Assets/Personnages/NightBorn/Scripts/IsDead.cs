using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsDead : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.x < -15.2)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}