using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICountResources : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _countBullet;
    [SerializeField] private TMP_Text _countHuman;

    private void OnEnable()
    {
        _shooting.Shot += ReloadText;
        _spawner.HumanDead += ReloadText;
        _spawner.HumanBorn += ReloadText;
    }

    private void OnDisable()
    {
        _shooting.Shot -= ReloadText;
        _spawner.HumanDead -= ReloadText;
        _spawner.HumanBorn -= ReloadText;
    }

    private void Start()
    {
        ReloadText();
    }

    private void ReloadText()
    {
        _countBullet.text = "Bullets: " + _shooting.CountBullets.ToString();
        _countHuman.text = "AlifeHuman: " + _spawner.AlifeHuman.ToString();
    }
}
