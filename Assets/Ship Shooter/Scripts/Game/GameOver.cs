using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEvent))]

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;

    private void OnEnable()
    {
        _gameEvent.Win += EndGame;
    }

    private void OnDisable()
    {
        _gameEvent.Win -= EndGame;
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        Debug.Log("You win!");
    }
}
