using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDead : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.x < -16)
        {
            Debug.Log("You are dead");
        }
    }
}
