using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    void Start()
    {
          GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Récupérer la position de respawn depuis PlayerPrefs
            float respawnPositionX = PlayerPrefs.GetFloat("RespawnPositionX");
            float respawnPositionY = PlayerPrefs.GetFloat("RespawnPositionY");
            Vector3 respawnPosition = new Vector3(respawnPositionX, respawnPositionY, player.transform.position.z);
            
            // Déplacer le joueur à la position de respawn
            player.transform.position = respawnPosition;

            Debug.Log("Player respawned at position: " + respawnPosition);
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }
}