using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        // Charger la scène spécifiée
        SceneManager.LoadScene(sceneName);

        // Vector3 lastFlagPosition = new Vector3(PlayerPrefs.GetFloat("LastFlagPositionX"), PlayerPrefs.GetFloat("LastFlagPositionY"), 0f);
        // PlayerPrefs.SetFloat("RespawnPositionX", lastFlagPosition.x);
        // PlayerPrefs.SetFloat("RespawnPositionY", lastFlagPosition.y);
    }
}
