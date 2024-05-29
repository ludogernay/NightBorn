using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject tilemapRenderer;

    private Vector3 respawnPosition;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float respawnPositionX = PlayerPrefs.GetFloat("RespawnPositionX");
            float respawnPositionY = PlayerPrefs.GetFloat("RespawnPositionY");
            respawnPosition = new Vector3(respawnPositionX, respawnPositionY, 0);
            if (respawnPosition.x == 0 && respawnPosition.y == 0)
            {
                respawnPosition = tilemapRenderer.transform.position;
            }
            
            tilemapRenderer.transform.position = respawnPosition;

            Debug.Log("Player respawned at position: " + respawnPosition);
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }
}