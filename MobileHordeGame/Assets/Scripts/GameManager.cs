using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent startGameEvent, pauseGameEvent, gameOverEvent, restartGameEvent;

    public void StartGame()
    {
        startGameEvent.Invoke();
    }

    public void PauseGame()
    {
        pauseGameEvent.Invoke();
    }

    public void GameOver()
    {
        gameOverEvent.Invoke();
    }

    public void RestartGame()
    {
        restartGameEvent.Invoke();
    }
}
