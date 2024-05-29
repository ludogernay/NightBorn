using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DecorScript : MonoBehaviour
{
    [SerializeField] private int pointsDeVie = 1;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private bool isVibrating = false;
    [SerializeField] private float particleMoveSpeed;

    TilemapRenderer _tilemapRenderer;
    TilemapCollider2D _tilemapCollider;

    public float maxDisplacement = 0.01f;
    public float vibrationSpeed = 5f;


    private Vector3 lastPosition;

    void Awake()
    {
        _tilemapRenderer = GetComponent<TilemapRenderer>();
        _tilemapCollider = GetComponent<TilemapCollider2D>();
        lastPosition = transform.position;
    }

    void Update()
    {
        if (pointsDeVie <= 0)
        {
            if (!isVibrating)
            {
                StartCoroutine(Death());
            }
        }
        else
        {
            if (transform.position != lastPosition)
            {
                lastPosition = transform.position;
                if (isVibrating)
                {
                    StopCoroutine(Vibrate());
                    isVibrating = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            pointsDeVie--;
            if(pointsDeVie >= 1)
            {
                if (!isVibrating)
                {
                    StartCoroutine(Vibrate());
                }
            }
        }
    }

    private IEnumerator Death()
    {
        isVibrating = true;
        var emission = _particleSystem.emission;
        emission.enabled = true;

        var velocityOverLifetime = _particleSystem.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
        velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(-particleMoveSpeed);
        _particleSystem.Play();

        _tilemapRenderer.enabled = false;
        _tilemapCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private IEnumerator Vibrate()
    {
        isVibrating = true;
        float startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float displacement = Mathf.Sin((Time.time - startTime) * vibrationSpeed) * maxDisplacement;
            Vector3 newPosition = transform.position;
            newPosition.x += displacement;
            transform.position = newPosition;
            yield return null;
        }
        transform.position = lastPosition;
        isVibrating = false;
    }
}