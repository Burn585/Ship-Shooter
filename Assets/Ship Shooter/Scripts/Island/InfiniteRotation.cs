using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InfiniteRotation : MonoBehaviour
{
    [SerializeField] private float _rotateY = -360f;

    private const int _infiniteLoop = -1;
    private float _speed = 40;
    private float _rotateX = 0f;
    private float _rotateZ = 0f;

    private void Start()
    {
        transform.DORotate(new Vector3(_rotateX, _rotateY, _rotateZ), _speed, RotateMode.FastBeyond360).SetLoops(_infiniteLoop, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }
}
