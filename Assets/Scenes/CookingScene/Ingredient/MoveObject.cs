using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(VelocityObserver))]
public class MoveObject : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float _moveSpeed = 40f;
    
    private Rigidbody2D _rigidbody;
    private VelocityObserver _velocityObserver;
    private bool _isDrag;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _velocityObserver = GetComponent<VelocityObserver>();
        MouseObserver.Instance.OnMouseUp += UnpinCursor;
    }

    public void SnapCursor()
    {
        _isDrag = true;
    }

    public void UnpinCursor()
    {
        _isDrag = false;
        _rigidbody.velocity = _velocityObserver.Velocity;
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

    public void OnPointerDown(PointerEventData eventData)
    {
        SnapCursor();
    }
}
