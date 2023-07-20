using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value;

    public event UnityAction<float> Hit;
    public event UnityAction Dead;

    public float Value => _value;

    public void TakeDamage(float damage)
    {
        _value -= damage;

        if (_value <= 0)
        {
            _value = 0;
            Dead?.Invoke();
            return;
        }

        Hit?.Invoke(_value);
    }
}
