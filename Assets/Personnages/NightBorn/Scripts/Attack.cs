using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public BoxCollider2D NightBorn_Sword;

    public float NightBorn_Sword_AttackDuration = 1.0f;

    public float NightBorn_Sword_AttackCooldown = 1.0f;

    public bool NightBorn_SwordIsActive = false;
    public Animator AttackAnim;
    public void Start()
    {
        NightBorn_Sword.enabled = false;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && NightBorn_Sword_AttackCooldown <= 0)
        {
            PlayerAttack();
        }
        else
        {
            EndPlayerAttack();
        }
    }
    void PlayerAttack()
    {
        if (!NightBorn_SwordIsActive)
        {
            AttackAnim.SetBool("attack",true);
            NightBorn_Sword_AttackCooldown = 1.0f;
            NightBorn_Sword_AttackDuration = 0.3f;
            NightBorn_Sword.enabled = true;
            NightBorn_SwordIsActive = true;
        }
    }

    void EndPlayerAttack()
    {
        NightBorn_Sword_AttackCooldown -= Time.deltaTime;
        NightBorn_Sword_AttackDuration -= Time.deltaTime;
        AttackAnim.SetBool("attack",false);
        if (NightBorn_Sword_AttackDuration <= 0)
        {
            NightBorn_Sword.enabled = false;
            NightBorn_SwordIsActive = false;
        }
    }
}