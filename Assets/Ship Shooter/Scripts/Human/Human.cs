using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] Spawner _spawner;

    private void OnEnable()
    {
        _health.Dead += Die;
    }

    private void OnDisable()
    {
        _health.Dead -= Die;
    }

    private void Die()
    {
        _spawner.AddInQueue(this);
    }
}
