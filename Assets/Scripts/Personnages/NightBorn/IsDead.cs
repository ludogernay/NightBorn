using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsDead : MonoBehaviour
{
    public Transform player;
    [SerializeField] private GameObject gameOverUI;
    void FixedUpdate()
    {
        if (player.position.x < -15.2 || player.position.y <= -11)
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
