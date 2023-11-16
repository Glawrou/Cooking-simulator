using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [field: SerializeField] public IngredientType IngredientType { get; private set; }
    [field: SerializeField] public MoveObject MoveObject { get; private set; }
}
