using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject drone;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        anim = drone.GetComponent<Animator>();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject projectile = Instantiate(bullet, new Vector2(drone.transform.position.x - 0.2f, drone.transform.position.y - 0.2f), Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-7, 0);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Shoot());
    }
}
