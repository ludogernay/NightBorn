using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject ParametreUI;
    // public TMP_Dropdown res;
    // public Slider VolumeSlider;
    // public TextMeshProUGUI Volume;
    // public TextMeshProUGUI textMeshPro;

    public static bool gamepause = false;
    public static bool param = false;
    public static PauseMenu instance;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
           if (param)
            {
                Masquer_Parametre();
            }else{

                if (gamepause)
                {
                    Resume();
                    gamepause = false;
                }
                else
                {
                    Paused();
                    gamepause = true;
                }
            }

       }
    }

    public void Paused()
    {
        if (NightBorn.instance != null)
        {
            NightBorn.instance.enabled = false;
        }

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gamepause = true;
    }


    public void Resume()
    {
        if (NightBorn.instance != null)
        {
            NightBorn.instance.enabled = true;
        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gamepause = false;  
    }

    public void QuitReturnToMenu()
    {
        NightBorn.instance.enabled = true;
        gamepause = false; 
        SceneManager.LoadScene("LevelMenu");
    }

    public void Aff_Parametre()
    {
        ParametreUI.SetActive(true);
        param = true;
    }

    public void Masquer_Parametre()
    {
        ParametreUI.SetActive(false);
        param = false;
    }
}