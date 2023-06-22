using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Castle : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private float _health;

    public event UnityAction<float> HitCastle;

    public float Health => _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            _health = 0;
            _gameEvent.SendWinGame();
        }

        HitCastle?.Invoke(_health);
    }
}
