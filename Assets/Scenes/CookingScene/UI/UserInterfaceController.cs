using System;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    public event Action OnPressRestart;

    [SerializeField] private Text _textScore;
    [SerializeField] private Button _buttonRestart;

    private void Start()
    {
        _buttonRestart.onClick.AddListener(() => OnPressRestart?.Invoke());
    }

    public void SetScore(int value)
    {
        _textScore.text = value.ToString();
    }
}
