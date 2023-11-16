using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(VelocityObserver))]
public class MoveObject : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 40f;
    [SerializeField, Range(0, 1)] private float _endSpeed = 1f;
    
    private Rigidbody2D _rigidbody;
    private VelocityObserver _velocityObserver;
    private bool _isDrag;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _velocityObserver = GetComponent<VelocityObserver>();
    }

    private void Update()
    {
        if (!_isDrag)
        {
            return;
        }

        FollowCursor();
    }

    private void FollowCursor()
    {
        var targetPos = Vector2.Lerp(_rigidbody.position,
               MouseObserver.Instance.MouseWorldPos,
               _moveSpeed * Time.deltaTime);

        _rigidbody.MovePosition(targetPos);
    }

    private void OnMouseDown()
    {
        _isDrag = true;
    }

    private void OnMouseUp()
    {
        _isDrag = false;
        _rigidbody.velocity = _velocityObserver.Velocity;
    }
}
