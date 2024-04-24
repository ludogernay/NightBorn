using UnityEngine;
using UnityEngine.Tilemaps;

public class flag : MonoBehaviour
{
    [SerializeField] private GameObject tilemapRenderer;

    private Vector3 Position;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Position = tilemapRenderer.transform.position;
            PlayerPrefs.SetFloat("RespawnPositionX", Position.x);
            PlayerPrefs.SetFloat("RespawnPositionY", Position.y);
            Debug.Log("Flag position: (" + Position.x + ", " + Position.y + ")");
        }
    }
}
