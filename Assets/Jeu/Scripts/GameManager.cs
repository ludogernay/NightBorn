using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> onGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        upDateGameState(GameState.Menu);
    }

    public void upDateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Menu:
                HandleOpenMenu();
                break;
            case GameState.Playing:
                HandlePLaying();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        onGameStateChanged?.Invoke(newState);
    }
    private void HandleOpenMenu()
    {
        // Open menu
    }
    private void HandlePLaying()
    {
        // playing
    }
    private void HandleGameOver()
    {
        // playing
    }
    private void HandleVictory()
    {
        // Victory screen
    }
}

public enum GameState
{
    Menu,
    Playing,
    GameOver,
    Victory
}
