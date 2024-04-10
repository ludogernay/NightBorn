using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnnemiHP : MonoBehaviour
{
    [SerializeField] private int pointsDeVie = 1;

    [SerializeField] ParticleSystem _particleSystem;

    SpriteRenderer _SpriteRenderer;
    Collider2D _Collider;

    private bool isDead = false;





    void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Collider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (pointsDeVie <= 0 && !isDead)
        {
            StartCoroutine(Death());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            pointsDeVie--;
        }
    }

    private IEnumerator Death()
    {
        isDead = true;
        _particleSystem.Play();
        _SpriteRenderer.enabled = false;
        _Collider.enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
