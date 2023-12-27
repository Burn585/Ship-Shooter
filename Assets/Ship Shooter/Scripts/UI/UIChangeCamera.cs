using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIChangeCamera : MonoBehaviour
{
    [SerializeField] private Camera[] _cameras;

    public event UnityAction<Camera> ChangeCamera;

    private int _currentCamera = 0;
    private int _firstCamera = 0;

    public void NextCamera()
    {
        _currentCamera++;

        if(_currentCamera == _cameras.Length)
        {
            _currentCamera = _firstCamera;
        }

        for(int i = 0; i < _cameras.Length; i++)
        {
            if (i == _currentCamera)
            {
                _cameras[i].gameObject.SetActive(true);
            }
            else
            {
                _cameras[i].gameObject.SetActive(false);
            }
        }

        ChangeCamera?.Invoke(_cameras[_currentCamera]);
    }
}
