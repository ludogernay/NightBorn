using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartPause : MonoBehaviour
{
    public Text countdownText;
    public float countdownTime = 3f;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }
    public void StartCountdownButton()
    {
        StartCoroutine(StartCountdown());
    }
    IEnumerator StartCountdown()
    {
        float currentTime = countdownTime;

        // Mettre la scène en pause pendant le compte à rebours
        Time.timeScale = 0f;

        while (currentTime > 0)
        {
            if (countdownText != null)
            {
                countdownText.text = currentTime.ToString("0");
            }
            yield return new WaitForSecondsRealtime(1f);
            currentTime--;
        }

        // Rétablir le temps normal après le compte à rebours
        Time.timeScale = 1f;

        // Effacer le texte une fois le décompte terminé
        if (countdownText != null)
        {
            countdownText.text = ""; // Effacer le texte
        }
    }
}
