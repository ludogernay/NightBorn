
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsDead : MonoBehaviour
{
    public Transform player;
    [SerializeField] private GameObject gameOverUI;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.x < -15.2)
        {
            GameOver();
            Time.timeScale = 0f;
            player.gameObject.SetActive(false);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
