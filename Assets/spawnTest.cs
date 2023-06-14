using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTest : MonoBehaviour
{
    [SerializeField] private Human _human;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit);
            for (int i = 0; i < 10; i++)
            {
                Instantiate(_human, hit.point, Quaternion.identity);
            }
        }
    }
}
