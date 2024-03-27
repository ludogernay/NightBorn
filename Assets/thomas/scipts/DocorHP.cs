using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DecorScript : MonoBehaviour
{
    public int pointsDeVie = 2;

    [SerializeField] ParticleSystem _particleSystem;

    TilemapRenderer _tilemapRenderer;
    TilemapCollider2D _tilemapCollider;

    private bool isDead = false;





    void Awake()
    {
        _tilemapRenderer = GetComponent<TilemapRenderer>();
        _tilemapCollider = GetComponent<TilemapCollider2D>();
    }
    void Update()
    {
        if (pointsDeVie <= 0 && !isDead)
        {
            StartCoroutine(Death());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
        _tilemapRenderer.enabled = false;
        _tilemapCollider.enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}