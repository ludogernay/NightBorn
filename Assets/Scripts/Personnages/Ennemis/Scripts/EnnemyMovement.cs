using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speedOut;
    public float speed;
    [SerializeField] private GameObject drone;
    [SerializeField] private Camera targetCamera;
    [SerializeField] SpriteRenderer _spriteRenderer;

    void Start()
    {
        rb = drone.GetComponent<Rigidbody2D>();
        anim = drone.GetComponent<Animator>();
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }
    }

    void Update()
    {
        if (IsVisibleFrom(_spriteRenderer, targetCamera))
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speedOut, 0);
        }
    }



    bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}