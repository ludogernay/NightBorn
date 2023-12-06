using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> onStateChanged;

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
                openMenu();
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                break;
            case GameState.Victory:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        onStateChanged?.Invoke(newState);
    }
    private void openMenu()
    {
        // Open menu
    }
}

public enum GameState
{
    Menu,
    Playing,
    GameOver,
    Victory
}