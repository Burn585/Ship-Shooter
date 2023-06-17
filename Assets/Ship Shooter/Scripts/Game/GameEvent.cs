using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    public event UnityAction<float> HitCastle;
    public event UnityAction Win;

    public void SendHitCastle(float hit)
    {
        HitCastle?.Invoke(hit);
    }

    public void SendWinGame()
    {
        Win?.Invoke();
    }
}
