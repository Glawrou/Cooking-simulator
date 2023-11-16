using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class Spawner : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Ingredient _ingredientVariant;

    public void OnPointerDown(PointerEventData eventData)
    {
        var ingredient = Instantiate(_ingredientVariant, MouseObserver.Instance.MouseWorldPos, Quaternion.identity, null);
        ingredient.MoveObject.SnapCursor();
    }
}
