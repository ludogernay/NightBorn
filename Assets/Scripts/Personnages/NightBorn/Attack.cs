using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D nightBornSword;
    [SerializeField] private float attackDuration = 0.3f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Animator attackAnim;

    [SerializeField] private bool swordIsActive;

    private void Start()
    {
        nightBornSword.enabled = false;
        swordIsActive = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && attackCooldown <= 0)
        {
            PlayerAttack();
        }
        else
        {
            EndPlayerAttack();
        }
    }

    private void PlayerAttack()
    {
        if (!swordIsActive)
        {
            attackDuration = 0.3f;
            attackCooldown = 0.5f;
            attackAnim.SetBool("attack", true);
            nightBornSword.enabled = true;
            swordIsActive = true;
        }
    }

    private void EndPlayerAttack()
    {
        attackDuration -= Time.deltaTime;
        attackAnim.SetBool("attack", false);
        if (attackDuration <= 0)
        {
            attackCooldown -= Time.deltaTime;
            nightBornSword.enabled = false;
            swordIsActive = false;
        }
    }
}
