using UnityEngine;
using System.Collections;

public class TransparencyFlipping : MonoBehaviour
{
    public float flipDuration = 1f;
    public float flipFrequency = 2f;

    private float currentAlpha = 0.4f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer otherSpriteRenderer;
    private bool isFadingOut = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FlipTransparency());
    }

    IEnumerator FlipTransparency()
    {
        while (true)
        {
            if (isFadingOut)
            {
                currentAlpha -= Time.deltaTime / flipDuration;
                if (currentAlpha <= 0.1f)
                {
                    currentAlpha = 0.1f;
                    isFadingOut = false;
                }
            }
            else
            {
                currentAlpha += Time.deltaTime / flipDuration;
                if (currentAlpha >= 0.4f)
                {
                    currentAlpha = 0.4f;
                    isFadingOut = true;
                }
            }

            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currentAlpha);
            otherSpriteRenderer.color = new Color(otherSpriteRenderer.color.r, otherSpriteRenderer.color.g, otherSpriteRenderer.color.b, currentAlpha + 0.2f);

            yield return new WaitForSeconds(flipFrequency);
        }
    }
}
