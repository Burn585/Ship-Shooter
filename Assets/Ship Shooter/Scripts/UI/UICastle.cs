using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICastle : MonoBehaviour
{
    [SerializeField] private Image _health;
    [SerializeField] private Castle _castle;

    private void OnEnable()
    {
        _castle.HitCastle += DrawHealth;
    }

    private void OnDisable()
    {
        _castle.HitCastle -= DrawHealth;
    }

    private void DrawHealth(float health)
    {
        float rate = 100;

        health /= rate;
        _health.fillAmount = health;
    }
}
