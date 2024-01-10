using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    void Awake()
    {
        GameManager.onGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        menuPanel.SetActive(state == GameState.Menu);
    }
    void onDestroy()
    {
        GameManager.onGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
