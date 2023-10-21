using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private int _firstLevel = 0;

    public void PlayLevel()
    {
        SceneManager.LoadScene(_firstLevel);
    }
}
