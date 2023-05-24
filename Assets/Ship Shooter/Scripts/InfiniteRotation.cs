using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InfiniteRotation : MonoBehaviour
{
    private float _speed = 15;

    private void Start()
    {
        transform.DORotate(new Vector3(0f, -360f, 0f), _speed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }
}
