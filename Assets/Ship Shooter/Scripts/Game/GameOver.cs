using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEvent))]

public class GameOver : MonoBehaviour
{
    [SerializeField] private Health _destroyCastle;
    [SerializeField] private Canvas _WinMenu;
    [SerializeField] private Shooting _shooting;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _destroyCastle.Dead += WinGame;
        _shooting.Shot += TryLose;
    }

    private void OnDisable()
    {
        _destroyCastle.Dead -= WinGame;
        _shooting.Shot -= TryLose;
    }

    private void WinGame()
    {
        Time.timeScale = 0;
        _WinMenu.gameObject.SetActive(true);
    }

    private void LoseGame()
    {
        Time.timeScale = 0;
        Debug.Log("You lose");
    }

    private void TryLose()
    {
        if(_shooting.CountBullets <= 0 && _spawner.LifeHuman > 0)
            LoseGame();
    }
}
