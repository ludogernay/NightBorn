using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlacement : MonoBehaviour
{
    public int initPositionX = -5;
    public float VitesseReplacement;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x < initPositionX)
        {
            player.position = new Vector2(player.position.x + VitesseReplacement/100, player.position.y);
        }
    }
}
