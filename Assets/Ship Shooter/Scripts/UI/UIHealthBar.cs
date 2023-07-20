using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Hit += DrawHealth;
    }

    private void OnDisable()
    {
        _health.Hit -= DrawHealth;
    }

    private void DrawHealth(float health)
    {
        float rate = 100;

        health /= rate;
        _healthBar.fillAmount = health;
    }
}
