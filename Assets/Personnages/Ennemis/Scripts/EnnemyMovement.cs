using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    [SerializeField] private GameObject drone;

    // Start is called before the first frame update
    void Start()
    {
        rb = drone.GetComponent<Rigidbody2D>();
        anim = drone.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed, 0);
    }
}
