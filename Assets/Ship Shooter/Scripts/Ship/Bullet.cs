using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeLife = 5;
    
    private void Start()
    {
        StartCoroutine(TimeLife());
    }

    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(_timeLife);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Tower>(out Tower tower))
        {
            Destroy(tower.gameObject);
        }

        if (collision.collider.TryGetComponent<Wall>(out Wall wall))
        {
            Destroy(wall.gameObject);
        }

        Destroy(gameObject);
    }
}
