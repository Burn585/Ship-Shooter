using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHuman : MonoBehaviour
{
    [SerializeField] private float _radius = 1;
    [SerializeField] private float _hit = 0.01f;
    [SerializeField] private LayerMask _layerMask;
    private GameEvent _gameEvent;
    private bool _attack = false;
    private WaitForSeconds _delayHit = new WaitForSeconds(1f);

    private void Start()
    {
        _gameEvent = FindObjectOfType<GameEvent>();
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, _radius, _layerMask) && _attack == false)
        {
            _attack = true;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            _gameEvent.SendHitCastle(_hit);

            yield return _delayHit;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
