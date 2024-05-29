using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToBossFight : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider entered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("ChangeScene");
            SceneManager.LoadScene("BossCutscene");
        }
    }
}
