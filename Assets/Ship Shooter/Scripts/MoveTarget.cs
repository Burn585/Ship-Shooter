using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private Camera _firstCamera;
    [SerializeField] private UIChangeCamera _btnNextCamera;

    private Camera _currentCamera;

    private void OnEnable()
    {
        _btnNextCamera.ChangeCamera += NextCamera;
    }

    private void OnDisable()
    {
        _btnNextCamera.ChangeCamera -= NextCamera;
    }

    private void Start()
    {
        _currentCamera = _firstCamera;
    }

    private void Update()
    {
        float enter;
        Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        new Plane(Vector3.up, hit.point).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);

        transform.position = mouseInWorld;
        //Quaternion q = Quaternion.LookRotation(Vector3.forward, hit.normal);
        //transform.rotation = q;
        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
    }

    private void NextCamera(Camera camera)
    {
        _currentCamera = camera;
    }
}
