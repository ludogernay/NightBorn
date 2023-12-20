using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointG;
    public GameObject pointD;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointD.transform;
        anim.SetBool("isPatroling", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointD.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointD.transform)
        {
            flip();
            currentPoint = pointG.transform;
        }      
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointG.transform)
        {
            flip();
            currentPoint = pointD.transform;
        }
        
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointG.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointD.transform.position, 0.5f);
        Gizmos.DrawLine(pointG.transform.position, pointD.transform.position);
    }
}
