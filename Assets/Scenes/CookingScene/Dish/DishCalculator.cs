using System.Linq;
using UnityEngine;

public class DishCalculator : MonoBehaviour
{
    [SerializeField] private IngredientScoreData[] _ingredientScore;

    public int Calculate(IngredientType[] ingredients)
    {
        return ingredients.Sum(ingredient => _ingredientScore.FirstOrDefault(d => d.Ingredient == ingredient)?.Score ?? 0);
    }
}
