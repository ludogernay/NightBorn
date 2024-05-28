using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackController : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;
    public GameObject bigBullet;
    public GameObject dangerZone;

    public float bulletSpeed = 12f;
    public float bulletDelay = 0.33f;
    public float attackInterval = 3f;

    private float elapsedTime = 0f;
    private bool isAttacking = false;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (!isAttacking && elapsedTime >= attackInterval)
        {
            StartCoroutine(ActivateAttack());
        }
    }

    IEnumerator ActivateAttack()
    {
        isAttacking = true;
        elapsedTime = 0f;
        animator.SetBool("isBulleting", true);

        Invoke("CreateBullet", bulletDelay);
        Invoke("CreateBullet", bulletDelay * 2);
        Invoke("CreateBullet", bulletDelay * 3);

        yield return new WaitForSeconds(1.683f);
        animator.SetBool("isBulleting", false);

        StartCoroutine(SpecialAttack());
    }

    IEnumerator SpecialAttack()
    {
        elapsedTime = 0f;
        yield return new WaitForSeconds(1f);
        animator.SetBool("isSpecial", true);
        dangerZone.SetActive(true);
        bigBullet.SetActive(true);
        bigBullet.transform.position = new Vector2(2.6f, -2.6f);

        float startTime = Time.time;
        float duration = 1.7f;
        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            bigBullet.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(2f, 2f, 2f), t);
            dangerZone.transform.localScale = Vector3.Lerp(new Vector3(14.9263f, 0f, 1f), new Vector3(14.9263f, 2f, 1f), t);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Rigidbody2D rb = bigBullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-20f, 0f);

        animator.SetBool("isSpecial", false);
        dangerZone.SetActive(false);
        yield return new WaitForSeconds(1f);
        bigBullet.SetActive(false);
        isAttacking = false;
    }

    private void CreateBullet()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = new Vector2(-bulletSpeed, 0f);
        Destroy(bulletInstance, 5f);
    }
}
