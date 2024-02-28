
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public Transform player;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private StartPause startPause;
    // Update is called once per frame
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float maxTime = 60f;
    private float elapsedTime;
    void Update()
    {
        Pause();
        if (player.position.x < -15.2)
        {
            GameOver();
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
        Time.timeScale = 0f;
        player.gameObject.SetActive(false);
    }
    public void PGbar()
    {
        if (elapsedTime < maxTime)
        {
            elapsedTime += Time.deltaTime;
            progressBar.fillAmount = elapsedTime / maxTime;
            timeText.text = (progressBar.fillAmount*100).ToString("F0") + "%";
        }
    }
    public void ChangeScene(string Scene)
    {
        // Charger la scène spécifiée
        SceneManager.LoadScene(Scene);
    }
    public void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        startPause.StartCountdownButton();
    }
}
