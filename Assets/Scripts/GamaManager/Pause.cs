using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private Gamemanager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<Gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.Pause();
    }
}
