using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DishView : MonoBehaviour
{
    [SerializeField] private Text _description;
    [SerializeField] private Text _name;

    public void Fill(Dish dish)
    {
        _name.gameObject.SetActive(true);
        _description.gameObject.SetActive(true);
        var ingredients = string.Join(", ", dish.Ingredients.Select(item => $"{item.Value} {item.Key}"));
        _description.text = $"{dish.Name} ({ingredients}) [{dish.Score}]";
    }
}
