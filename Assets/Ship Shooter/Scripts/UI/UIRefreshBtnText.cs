using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIRefreshBtnText : MonoBehaviour
{
    [SerializeField] private UIChangeAngle _btnAngle;
    [SerializeField] private UIChangeCamera _btnCamera;

    private TMP_Text _textAngle;
    private TMP_Text _textCamera;

    private void OnEnable()
    {
        _btnAngle.ChangeAngle += RefreshAngle;
        _btnCamera.ChangeCamera += RefreshCamera;
    }

    private void OnDisable()
    {
        _btnAngle.ChangeAngle -= RefreshAngle;
        _btnCamera.ChangeCamera += RefreshCamera;
    }

    private void Start()
    {
        //�������� ��� ���� � requirecomponent???? �������� ������ � serializefield??????
        _textAngle = _btnAngle.GetComponentInChildren<TMP_Text>();
        _textCamera = _btnCamera.GetComponentInChildren<TMP_Text>();
    }

    private void RefreshAngle(int angle)
    {
        _textAngle.text = "Angle: " + angle;
    }

    private void RefreshCamera(Camera camera)
    {
        _textCamera.text = camera.gameObject.name;
    }
}
