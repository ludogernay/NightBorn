using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        // Charger la scène spécifiée
        SceneManager.LoadScene(sceneName);
    }
    
    public void ReturnToLevel(string sceneName)
    {
        // Récupérer la dernière position du checkpoint via le singleton
        Vector3 respawnPosition = CheckPointManager.Instance.GetLastCheckPointPosition();

        // Charger la scène du niveau
        SceneManager.LoadScene(sceneName);

        // Replacer le joueur à la dernière position de checkpoint
        check player = FindObjectOfType<check>();
        if (player != null)
        {
            player.RespawnAtLastCheckPoint(respawnPosition);
        }
        else
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }
}