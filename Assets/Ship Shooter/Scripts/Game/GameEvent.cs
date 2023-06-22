using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    public event UnityAction Win;

    public void SendWinGame()
    {
        Win?.Invoke();
    }
}
