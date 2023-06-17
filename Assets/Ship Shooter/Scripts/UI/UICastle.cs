using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICastle : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private Image _health;

    private void OnEnable()
    {
        _gameEvent.HitCastle += TakeDamage;
    }

    private void OnDisable()
    {
        _gameEvent.HitCastle -= TakeDamage;
    }

    private void TakeDamage(float damage)
    {
        _health.fillAmount -= damage;
    }
}
