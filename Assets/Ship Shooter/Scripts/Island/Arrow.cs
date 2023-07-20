using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _speed = 5;

    private Transform _target;
    private float _distanceDestroy = 0.1f;

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.position += (dir.normalized * Time.deltaTime * _speed);

        if(Vector3.Distance(_target.position, transform.position) < _distanceDestroy)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Human>(out Human human))
        {
            _spawner.AddInQueue(human);
        }

        Destroy(this.gameObject);
    }
}
