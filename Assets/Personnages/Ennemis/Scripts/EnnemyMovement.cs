using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    [SerializeField] private string drone;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.Find(drone).GetComponent<Rigidbody2D>();
        anim = transform.Find(drone).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed, 0);
    }
}
