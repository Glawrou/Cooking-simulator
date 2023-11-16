using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action<GameObject> OnTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnter?.Invoke(collision.gameObject);
    }
}
