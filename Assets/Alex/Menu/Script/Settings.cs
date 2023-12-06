using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider VolumeSlider;
    public TMP_Dropdown res;
    public AudioSource audioSource;
    public TextMeshProUGUI Volume;
    public void sons()
    {
       audioSource.volume = VolumeSlider.value;
       Volume.text = "Volume  " + (audioSource.volume * 100).ToString("00") + "%";
    }

    public void SetResolution()
    {
        switch(res.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;

            case 1:
                Debug.Log("non");
                Screen.SetResolution(640, 360, true);
                break;
        }
    }
}
