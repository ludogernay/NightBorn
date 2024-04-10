using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] int maxHP;
    int currentHP;
    public Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] TextMeshPro hpText;

    void Start(){
        currentHP = maxHP;
        UpdateHPView();
        hpText.color = Color.yellow;
    }

    public void takeDamage(int damage){
        currentHP = Mathf.Max(currentHP - damage, 0);
        UpdateHPView();
    }

    void UpdateHPView(){

        if (currentHP <= 0) {
            currentHP = 0;
            spriteRenderer.color = Color.red;
            hpText.color = Color.red;
            Destroy(GetComponent<AttackController>());
            animator.SetBool("isDead", true);
            animator.SetBool("isBulleting", false);
        }

        hpText.text = "HP: " + currentHP.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BulletController otherBulletController = other.GetComponent<BulletController>();
        if (otherBulletController != null)
        {
            currentHP -= 10;
            UpdateHPView();
            StartCoroutine(FlashRed());
        }
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
