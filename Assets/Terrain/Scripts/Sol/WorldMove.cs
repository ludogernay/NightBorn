using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    public GameObject wall;

    public float speedGround ;

    // Update is called once per frame
    void FixedUpdate()
    {
        wall.transform.position = new Vector2(wall.transform.position.x - speedGround, wall.transform.position.y);
    }
}
