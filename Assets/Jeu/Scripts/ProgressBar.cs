using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Image progressBar;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float maxTime = 60f;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        progressBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < maxTime)
        {
            elapsedTime += Time.deltaTime;
            progressBar.fillAmount = elapsedTime / maxTime;
            timeText.text = (progressBar.fillAmount*100).ToString("F0") + "%";
        }
    }
}
