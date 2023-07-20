using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _radius = 7;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private float _delay = 1;

    private Vector3 _center;

    private void Start()
    {
        StartCoroutine(SearchTarget());
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            _center = transform.position;

            Collider[] colliders = Physics.OverlapSphere(_center, _radius);

            Collider collider = colliders.FirstOrDefault(item => item.GetComponent<Human>());

            if(collider != null)
            {
                Shot(collider.transform);
            }

            yield return new WaitForSeconds(_delay);
        }
    }

    private void Shot(Transform target)
    {
        Vector3 derection = transform.position - target.position;

        var arrow = Instantiate(_arrow, transform.position, Quaternion.identity, transform.parent);
        arrow.gameObject.SetActive(true);
        arrow.SetTarget(target);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(_center, _radius);
    }
}
