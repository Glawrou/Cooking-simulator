using System;
using UnityEngine;

public class MouseObserver : MonoBehaviour
{
    public event Action OnMouseUp;

    public static MouseObserver Instance { get; private set; }

    [SerializeField] private Camera _camera;

    public Vector2 MouseWorldPos => _camera.ScreenToWorldPoint(Input.mousePosition);

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp?.Invoke();
        }
    }
}
