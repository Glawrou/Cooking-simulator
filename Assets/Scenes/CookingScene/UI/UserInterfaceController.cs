using System;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    public event Action OnPressRestart;

    [SerializeField] private Text _textScore;
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private DishView _lastDish;
    [SerializeField] private DishView _bestDish;

    private void Start()
    {
        _buttonRestart.onClick.AddListener(() => OnPressRestart?.Invoke());
    }

    public void SetScore(int value)
    {
        _textScore.text = value.ToString();
    }

    public void SetLastDish(Dish dish)
    {
        _lastDish.Fill(dish);
    }

    public void SetBestDish(Dish dish)
    {
        _bestDish.Fill(dish);
    }
}
