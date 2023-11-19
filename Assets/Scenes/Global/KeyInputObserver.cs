using UnityEngine;
using System;

public class KeyInputObserver : MonoBehaviour
{
    public event Action OnRestart;
    public event Action OnClose;

    [SerializeField] private KeyCode _restartGameKey;
    [SerializeField] private KeyCode _closeApplicationKey;

    private void Update()
    {
        if (Input.GetKeyUp(_restartGameKey))
        {
            OnRestart?.Invoke();
        }
        else if (Input.GetKeyUp(_closeApplicationKey))
        {
            OnClose?.Invoke();
        }
    }
}
