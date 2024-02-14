using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnnemyBomber : MonoBehaviour
{
    public GameObject pointG;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.Find("drone 2 Drop_0").GetComponent<Rigidbody2D>();
        anim = transform.Find("drone 2 Drop_0").GetComponent<Animator>();
        currentPoint = pointG.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointG.transform.position, 0.5f);
        Gizmos.DrawLine(transform.Find("drone 2 Drop_0").position, pointG.transform.position);
    }

}
