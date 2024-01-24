using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void ChangeScene(string Scene)
    {
        // Charger la scène spécifiée
        SceneManager.LoadScene(Scene);
    }
}
    // public void NxtScene()
    // {
    //     StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    // }

    // IEnumerator LoadLevel(int levelIndex)
    // {
    //     yield return new WaitForSeconds(1.0f);

    //     SceneManager.LoadScene(levelIndex);
    // }