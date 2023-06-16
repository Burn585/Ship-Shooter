using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Human _human;
    [SerializeField] private float _count;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<Bullet>(out Bullet bullet))
        {
            for (int i = 0; i < _count; i++)
            {
                Instantiate(_human, bullet.transform.position, Quaternion.identity, transform.parent);
            }
        }
    }
}