using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DishCalculator : MonoBehaviour
{
    [SerializeField] private IngredientScoreData[] _ingredientScore;
    [SerializeField] private ComboData[] _combo;
    [SerializeField] private RecipesData _recipesData;

    public Dish CreateDish(PotContents potContents)
    {
        var countsGroups = GroupIngredients(potContents.Ingredients);
        return new Dish()
        {
            Name = NameCalculate(countsGroups),
            Ingredients = countsGroups,
            Score = Calculate(countsGroups)
        };
    }

    private string NameCalculate(Dictionary<IngredientType, int> countsGroups)
    {
        var matchingRecipe = _recipesData.Recipes
            .FirstOrDefault(recipe =>
                countsGroups.TryGetValue(recipe.Ingredient, out var count) &&
                recipe.MinAmount <= count && count <= recipe.MaxAmount
            );

        return matchingRecipe?.Name ?? _recipesData.DefaultReciepeName;
    }

    private int Calculate(Dictionary<IngredientType, int> countsGroups)
    {
        Debug.Log(NameCalculate(countsGroups));
        var score = countsGroups.Sum(item =>
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
