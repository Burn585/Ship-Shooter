using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionWalls : MonoBehaviour
{
    [SerializeField] private Destroyable _fullHealth;
    [SerializeField] private Destroyable _middleHealth;
    [SerializeField] private Destroyable _lowHealth;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Hit += Damage;
        _health.Dead += DeleteWall;
    }

    private void OnDisable()
    {
        _health.Hit -= Damage;
        _health.Dead -= DeleteWall;
    }

    private void Damage(float damage)
    {
        switch (_health.Value)
        {
            case 2:
                _fullHealth.gameObject.SetActive(false);
                _middleHealth.gameObject.SetActive(true);
                break;
            case 1:
                _middleHealth.gameObject.SetActive(false);
                _lowHealth.gameObject.SetActive(true);
                break;
        }
    }

    private void DeleteWall()
    {
        Destroy(this.gameObject);
    }
}
