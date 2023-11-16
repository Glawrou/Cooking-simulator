using System;
using UnityEngine;

public class Dish
{
    public bool IsReadyDish => _indexIngredient == DishSize;
    public IngredientType[] Ingredients { get; private set; }

    private const int DishSize = 5;

    private int _indexIngredient = 0;

    public Dish()
    {
        Ingredients = new IngredientType[DishSize];
    }

    public void AddIngredient(IngredientType ingredientType)
    {
        if (_indexIngredient == DishSize)
        {
            Debug.Log("Dish >> Dish is ready");
            return;
        }

        Ingredients[_indexIngredient++] = ingredientType;
    }
}
