using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public Animator transition; //récupère l'animator choisi
    // public SO1 so;

    public float transitionTime = 1f; // variable du temps de transition
    
    public void NxtScene(){ // Charge la scène suivante dans l'index avec les transitions
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }
    public void NxtSceneMove(){ // charge la scène "Move"
        StartCoroutine(LoadLevel(1));
    }

    // Charge la scène suivante dans l'index avec les transitions
    // public void NewGame(){ 
    //     so.win1 = false;
    //     so.win2 = false;
    //     so.win3 = false;
    //     so.win4 = false;
    //     so.playerPos = new Vector2(2.7436f,-0.1947f);
    //     StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    // }

IEnumerator LoadLevel (int levelIndex)
{
    transition.SetTrigger("Start"); // trigger la transition

    yield return new WaitForSeconds(transitionTime); // attends avant de charger la scène
    
    SceneManager.LoadScene(levelIndex);

}

}
