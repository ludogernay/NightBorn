using System.Timers;
using UnityEditor;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed = 12f;
    private float bulletDelay = 0.33f;
    private float elapsedTime;
    private void Start()
    {
        InvokeRepeating("ActivateAttackAnimation", 0f, 3f);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1.666666666666667f)
        {
            animator.SetBool("isBulleting", false);
            elapsedTime = 0;
        }

    }

    private void ActivateAttackAnimation()
    {
        elapsedTime = 0;
        animator.SetBool("isBulleting", true);
        Invoke("CreateBullet", bulletDelay);
        Invoke("CreateBullet", bulletDelay * 2);
        Invoke("CreateBullet", bulletDelay * 3);
    }

    private void CreateBullet()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = new Vector2(-bulletSpeed, 0f);
        Destroy(bulletInstance, 5f);
    }
}
