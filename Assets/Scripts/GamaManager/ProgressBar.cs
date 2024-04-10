using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Gamemanager gamemanager;
    // Update is called once per frame
    void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
    }
    // void Update()
    // {
    //     gamemanager.PGbar();
    // }
}
