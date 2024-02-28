using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private Gamemanager _gamemanager;
    void Start()
    {
        _gamemanager = FindObjectOfType<Gamemanager>();
    }

    // Update is called once per frame
    void OncolliderEnter2D(Collider2D other)
    {
        _gamemanager.GameOver();
    }
}
