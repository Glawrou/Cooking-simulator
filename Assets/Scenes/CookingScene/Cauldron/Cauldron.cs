using System;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public event Action<Ingredient> OnAddIngredient;

    [SerializeField] private Trigger _deadZone;

    private void Start()
    {
        _deadZone.OnTriggerEnter += TriggerDeadZoneHandler;
    }

    private void TriggerDeadZoneHandler(GameObject gameObject)
    {
        var ingredient = gameObject.GetComponent<Ingredient>();
        if (ingredient)
        {
            OnAddIngredient?.Invoke(ingredient);
        }
    }
}
