using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DishCalculator : MonoBehaviour
{
    [SerializeField] private IngredientScoreData[] _ingredientScore;
    [SerializeField] private ComboData[] _combo;

    public int Calculate(IngredientType[] ingredients)
    {
        var counts = GroupIngredients(ingredients);
        var score = counts.Sum(item =>
        {
            var ingredientScore = _ingredientScore.FirstOrDefault(i => i.Ingredient == item.Key)?.Score ?? 0;
            var comboMultiplier = _combo.FirstOrDefault(c => c.CountIdentical == item.Value)?.Multiplier ?? 1;
            return ingredientScore * comboMultiplier * item.Value;
        });

        return Mathf.RoundToInt(score);
    }

    private Dictionary<IngredientType, int> GroupIngredients(IngredientType[] ingredients)
    {
        return ingredients
            .GroupBy(ingredient => ingredient)
            .ToDictionary(group => group.Key, group => group.Count());
    }
}
