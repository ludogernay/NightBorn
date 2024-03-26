using UnityEngine;
using System.Collections;

public class tirlaser : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileParent;
    public float speed = 2f;

    void Start()
    {
        StartCoroutine(ShootProjectile());
    }

    IEnumerator ShootProjectile()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(92f, -5.8f, 0f);
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity, projectileParent);
            
            while (projectile != null && projectile.transform.position.x > -20f)
            {
                projectile.transform.Translate(Vector3.left * speed * Time.deltaTime);
                yield return null;
            }
            
            if(projectile != null)
                Destroy(projectile);

            yield return new WaitForSeconds(2f);
        }
    }
}
