using UnityEngine;

public class CookingController : MonoBehaviour
{
    [SerializeField] private Cauldron _cauldron;

    private void Start()
    {
        _cauldron.OnAddIngredient += AddIngredientHandler;
    }

    private void AddIngredientHandler(Ingredient ingredient)
    {
        Destroy(ingredient.gameObject);
    }
}
