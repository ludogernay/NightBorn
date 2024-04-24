using UnityEngine;

public class flag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 flagPosition = transform.position;
            PlayerPrefs.SetFloat("LastFlagPositionX", flagPosition.x);
            PlayerPrefs.SetFloat("LastFlagPositionY", flagPosition.y);
             Debug.Log("Flag position: (" + flagPosition.x + ", " + flagPosition.y + ")");
        }
    }
}
