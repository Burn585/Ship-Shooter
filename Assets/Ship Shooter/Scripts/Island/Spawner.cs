using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Human _human;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<Bullet>(out Bullet bullet))
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(_human, bullet.transform.position, Quaternion.identity, transform.parent);
            }
        }
    }
}