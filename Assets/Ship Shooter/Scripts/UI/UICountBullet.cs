using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICountBullet : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;

    private TMP_Text _countBullet;

    private void OnEnable()
    {
        _shooting.Shot += ReloadText;
    }

    private void OnDisable()
    {
        _shooting.Shot -= ReloadText;
    }

    private void Start()
    {
        _countBullet = GetComponent<TMP_Text>();
        _countBullet.text = _shooting.CountBullets.ToString();
    }

    private void ReloadText()
    {
        _countBullet.text = _shooting.CountBullets.ToString();
    }
}
