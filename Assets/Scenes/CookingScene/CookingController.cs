using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingController : MonoBehaviour
{
    [SerializeField] private Cauldron _cauldron;
    [SerializeField] private UserInterfaceController _userInterfaceController;
    [SerializeField] private DishCalculator _dishCalculator;

    private int _score;
    private Dish _dish;

    private void Start()
    {
        CreateNewDish();
        _cauldron.OnAddIngredient += AddIngredientHandler;
        _userInterfaceController.OnPressRestart += RestartLevel;
    }

    private void AddIngredientHandler(Ingredient ingredient)
    {
        _dish.AddIngredient(ingredient.IngredientType);
        if (_dish.IsReadyDish)
        {
            _score += _dishCalculator.Calculate(_dish.Ingredients);
            _userInterfaceController.SetScore(_score);
            CreateNewDish();
        }

        Destroy(ingredient.gameObject);
    }

    private void CreateNewDish()
    {
        _dish = new Dish();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
