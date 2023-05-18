using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistics : MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _angleToDegrees;
    [SerializeField] private Bullet _bullet;

    private float g = Physics.gravity.y;

    private void Update()
    {
        _spawnTransform.localEulerAngles = new Vector3(-_angleToDegrees, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        Vector3 fromTo = _targetTransform.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float angleToRadians = _angleToDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleToRadians) * x) * Mathf.Pow(Mathf.Cos(angleToRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        var bullet = Instantiate(_bullet, _spawnTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = _spawnTransform.forward * v;
    }
}
