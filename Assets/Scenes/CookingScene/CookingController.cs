using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class CookingController : MonoBehaviour
{
    [SerializeField] private Cauldron _cauldron;
    [SerializeField] private UserInterfaceController _userInterfaceController;
    [SerializeField] private DishCalculator _dishCalculator;
    [SerializeField] private KeyInputObserver _keyInputObserver;

    private const string IngredientsScoreNameFile = "IngredientsScoreData";

    private List<Dish> _listDish;
    private PotContents _potContents;

    private void Start()
    {
        ClearPot();
        _listDish = new List<Dish>();
        _dishCalculator.Init(JsonReader.Read<IngredientsScoreData>(IngredientsScoreNameFile));
        _cauldron.OnAddIngredient += AddIngredientHandler;
        _userInterfaceController.OnPressRestart += RestartLevel;
        _keyInputObserver.OnRestart += RestartLevel;
        _keyInputObserver.OnClose += ApplicationQuit;
    }

    private void UpdateUI()
    {
        _userInterfaceController.SetScore(_listDish.Sum(d => d.Score));
        _userInterfaceController.SetLastDish(_listDish.Last());
        _userInterfaceController.SetBestDish(_listDish.FirstOrDefault(d => d.Score == _listDish.Max(s => s.Score)));
    }

    private void AddIngredientHandler(Ingredient ingredient)
    {
        _potContents.AddIngredient(ingredient.IngredientType);
        if (_potContents.IsReadyDish)
        {
            _listDish.Add(_dishCalculator.CreateDish(_potContents));
            UpdateUI();
            ClearPot();
        }

        Destroy(ingredient.gameObject);
    }

    private void ClearPot()
    {
        _potContents = new PotContents();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ApplicationQuit()
    {
        Application.Quit();
    }
}
