using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        float enter;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.up, transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);

        transform.position = mouseInWorld;
    }
}
