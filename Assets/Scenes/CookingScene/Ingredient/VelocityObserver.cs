using UnityEngine;

public class VelocityObserver : MonoBehaviour
{
    public Vector2 Velocity { get; private set; }

    private Vector3 _previousPosition;

    private void Start()
    {
        _previousPosition = transform.position;
    }

    private void Update()
    {
        var currentPosition = transform.position;
        var positionDelta = currentPosition - _previousPosition;
        Velocity = positionDelta / Time.deltaTime;
        _previousPosition = currentPosition;
    }
}
