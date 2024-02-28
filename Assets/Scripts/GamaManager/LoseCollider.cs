using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private Gamemanager _gamemanager;
    void Start()
    {
        _gamemanager = FindObjectOfType<Gamemanager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Game Over");
        _gamemanager.GameOver();
    }
}
