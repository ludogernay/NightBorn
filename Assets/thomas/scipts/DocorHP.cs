using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DecorScript : MonoBehaviour
{
    [SerializeField] private int pointsDeVie = 2;

    [SerializeField] ParticleSystem _particleSystem;

    TilemapRenderer _tilemapRenderer;
    TilemapCollider2D _tilemapCollider;

    private bool isDead = false;

    [SerializeField] private float maxDisplacement = 0.03f;
    [SerializeField] private float vibrationSpeed = 50f;
    private Vector3 initialPosition;

    void Awake()
    {
        _tilemapRenderer = GetComponent<TilemapRenderer>();
        _tilemapCollider = GetComponent<TilemapCollider2D>();
        initialPosition = transform.position;
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

            StartCoroutine(Vibrate());
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

    private IEnumerator Vibrate()
    {
        float startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float displacement = Mathf.Sin((Time.time - startTime) * vibrationSpeed) * maxDisplacement;
            Vector3 newPosition = initialPosition;
            newPosition.x += displacement;
            transform.position = newPosition;
            yield return null;
        }
        transform.position = initialPosition;
    }
}