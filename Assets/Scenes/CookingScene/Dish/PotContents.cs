using System;
using UnityEngine;

public class PotContents
{
    public bool IsReadyDish => _indexIngredient == PotSize;
    public IngredientType[] Ingredients { get; private set; }

    private const int PotSize = 5;

    private int _indexIngredient = 0;

    public PotContents()
    {
        Ingredients = new IngredientType[PotSize];
    }

    public void AddIngredient(IngredientType ingredientType)
    {
        if (_indexIngredient == PotSize)
        {
            Debug.Log("Dish >> Dish is ready");
            return;
        }

        Ingredients[_indexIngredient++] = ingredientType;
    }
}
