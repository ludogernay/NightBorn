using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private Vector3 Position;
    public void ChangeScene(string sceneName)
    {
        PlayerPrefs.SetFloat("RespawnPositionX", 0);
        PlayerPrefs.SetFloat("RespawnPositionY", 0);
        SceneManager.LoadScene(sceneName);
    }

    public void Resart(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }


}
