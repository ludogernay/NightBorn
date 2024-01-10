using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public GameObject wall;
    public GameObject Background;

    public float speedGround ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wall.transform.position = new Vector2(wall.transform.position.x - speedGround, wall.transform.position.y);
    }
}
