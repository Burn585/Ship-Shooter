using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private GameEvent _gameEvent;
 
    public float Health => _health;

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
        _health -= damage;

        if(_health <= 0)
        {
            _gameEvent.SendWinGame();
        }
    }
}
