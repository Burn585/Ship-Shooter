using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEvent))]

public class GameOver : MonoBehaviour
{
    [SerializeField] private Health _destroyCastle;
    [SerializeField] private Canvas _winMenu;
    [SerializeField] private Canvas _loseMenu;
    [SerializeField] private Shooting _shooting;
    [SerializeField] private Spawner _spawner;

    private WaitForSeconds delay = new WaitForSeconds(2);

    private void OnEnable()
    {
        _destroyCastle.Dead += WinGame;
        _shooting.Shot += LoseGame;
        _spawner.HumanDead += LoseGame;
    }

    private void OnDisable()
    {
        _destroyCastle.Dead -= WinGame;
        _shooting.Shot -= LoseGame;
        _spawner.HumanDead -= LoseGame;
    }

    private void WinGame()
    {
        Time.timeScale = 0;
        _winMenu.gameObject.SetActive(true);
    }

    private void LoseGame()
    {
        StartCoroutine(TryLose());
    }

    private IEnumerator TryLose()
    {
        if (_shooting.CountBullets <= 0 && _spawner.AlifeHuman == 0)
        {
            yield return delay;
            Time.timeScale = 0;
            _loseMenu.gameObject.SetActive(true);
        }
    }
}
