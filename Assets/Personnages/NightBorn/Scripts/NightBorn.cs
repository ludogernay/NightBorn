using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorn : MonoBehaviour
{
    public Rigidbody2D nightBornRB;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public float jumpForce;
    private int maxJumps = 1; // Nombre maximum de sauts
    private bool isGrounded;
    private int jumpsLeft;


    // Start is called before the first frame update
    void Start()
    {
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            PlayerJump();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            maxJumps = 2;
        }
        if (isGrounded && (nightBornRB.velocity.y == 0f))
        {
            jumpsLeft = maxJumps;
        }
    }

    void PlayerJump()
    {
        Debug.Log(isGrounded);
        nightBornRB.velocity = new Vector2(nightBornRB.velocity.x, 0f); // Réinitialise la vélocité en y avant de sauter
        nightBornRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        jumpsLeft--; // Décrémente jumpsLeft si le joueur est en l'air
    }

}
