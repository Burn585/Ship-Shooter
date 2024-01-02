using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIChangeAngle : MonoBehaviour
{
    [SerializeField] private int _highAngle = 70;
    [SerializeField] private int _middleAngle = 50;
    [SerializeField] private int _lowAngle = 25;

    public event UnityAction<int> ChangeAngle;

    private int _currentAngle;
    private Queue<int> _angles = new Queue<int>();

    private void Start()
    {
        _angles.Enqueue(_highAngle);
        _angles.Enqueue(_middleAngle);
        _angles.Enqueue(_lowAngle);
        _currentAngle = _angles.Dequeue();
        ChangeAngle?.Invoke(_currentAngle);
    }

    public void NextAngle()
    {
        _angles.Enqueue(_currentAngle);
        _currentAngle = _angles.Dequeue();
        ChangeAngle?.Invoke(_currentAngle);
    }
}
