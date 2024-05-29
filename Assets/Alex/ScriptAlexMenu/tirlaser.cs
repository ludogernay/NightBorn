using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class tirlaser : MonoBehaviour
{
    public GameObject spawnPoint; 
    public GameObject projectilePrefab;
    public Transform projectileParent;
    public float speed = 2f;

    private void Start()
    {
        StartCoroutine(ShootProjectile());
    }

    private IEnumerator ShootProjectile()
    {
        while (true)
        {
            // Utilise la position du spawnPoint pour le spawn du projectile
            Vector3 spawnPosition = spawnPoint.transform.position;

            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity, projectileParent);
            Debug.Log("oui");

            while (projectile != null)
            {
                projectile.transform.Translate(Vector3.left * speed * Time.deltaTime);

                // if (!IsProjectileInScreen(projectile.transform.position))
                // {
                //     Destroy(projectile); 
                //     break;
                // }

                yield return null;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private bool IsProjectileBehindPlayer(Vector3 position)
    {
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(GameObject.FindGameObjectWithTag("Player").transform.position);

        Vector3 projectileScreenPos = Camera.main.WorldToScreenPoint(position);

        return projectileScreenPos.x < playerScreenPos.x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
