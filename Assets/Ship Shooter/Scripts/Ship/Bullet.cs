using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeLife = 5;

    private float _bonus = 1;

    public float Bonus => _bonus;
    
    private void Start()
    {
        StartCoroutine(TimeLife());
    }

    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(_timeLife);
        Destroy(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Destroyable>(out Destroyable destroyable))
        {
            Destroy(destroyable.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.collider.TryGetComponent<Island>(out Island island))
        {
            Destroy(this.gameObject);
        }

        if (collision.collider.TryGetComponent<Bonus>(out Bonus bonus))
        {
            _bonus *= bonus.Value;
            Destroy(bonus.gameObject);
        }
    }
}
