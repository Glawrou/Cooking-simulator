using System;

[Serializable]
public class Recipe
{
    public string Name;
    public IngredientType Ingredient;
    public int MinAmount;
    public int MaxAmount;
}
