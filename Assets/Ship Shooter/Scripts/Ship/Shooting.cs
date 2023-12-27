using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _angleToDegrees;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _countBullets = 10;

    public event UnityAction Shot;

    private float g = Physics.gravity.y;

    public int CountBullets => _countBullets;


    private void Update()
    {
        float spawnY = 0f;
        float spawnZ = 0f;

        _spawnTransform.localEulerAngles = new Vector3(-_angleToDegrees, spawnY, spawnZ);

        if (Input.GetMouseButtonUp(0) && _countBullets > 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            Fire();
        }
    }

    private void Fire()
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
        _countBullets--;
        Shot?.Invoke();
    }
}
