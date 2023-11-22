using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorn : MonoBehaviour
{
    public Rigidbody2D nightBornRB;

    public BoxCollider2D NightBorn_Sword;

    public float NightBorn_Sword_AttackDuration = 1.0f;

    public float NightBorn_Sword_AttackCooldown = 1.0f;

    public bool NightBorn_SwordIsActive = false;
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

        if (Input.GetMouseButtonDown(0) && NightBorn_Sword_AttackCooldown <= 0)
        {
            PlayerAttack();
        }
        else
        {
            EndPlayerAttack();
        }


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
        Debug.Log("Night_Born is on Ground : " + isGrounded);
        nightBornRB.velocity = new Vector2(nightBornRB.velocity.x, 0f); // Réinitialise la vélocité en y avant de sauter
        nightBornRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        jumpsLeft--; // Décrémente jumpsLeft si le joueur est en l'air
    }

    void PlayerAttack()
    {
        if (!NightBorn_SwordIsActive)
        {
            NightBorn_Sword_AttackCooldown = 1.0f;
            NightBorn_Sword_AttackDuration = 0.3f;
            Debug.Log("Night_Born Attack");
            NightBorn_Sword.enabled = true;
            NightBorn_SwordIsActive = true;
            Debug.Log("NightBorn_SwordColliderEnabled : " + NightBorn_Sword.enabled);
        }
    }

    void EndPlayerAttack()
    {
        NightBorn_Sword_AttackCooldown -= Time.deltaTime;
        NightBorn_Sword_AttackDuration -= Time.deltaTime;
        if (NightBorn_Sword_AttackDuration <= 0)
        {
            NightBorn_Sword.enabled = false;
            NightBorn_SwordIsActive = false;
            Debug.Log("NightBorn_SwordColliderEnabled : " + NightBorn_Sword.enabled);
        }
    }
}
