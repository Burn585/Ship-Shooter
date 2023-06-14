using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Pitching : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _torqueZ = 1f;

    private void OnEnable()
    {
        _shooting.Shot += Push;
    }

    private void OnDisable()
    {
        _shooting.Shot -= Push;
    }

    private void Push()
    {
        float torqueX = 0;
        float torqueY = 0;

        _rigidbody.AddTorque(new Vector3(torqueX, torqueY, _torqueZ), ForceMode.Impulse);
    }
}
