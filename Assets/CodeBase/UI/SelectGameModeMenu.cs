using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class SelectGameModeMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _gameModesDropdown;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _startGameButton;

    private Dictionary<int, GameMode> _gameModesMap = new Dictionary<int, GameMode>();
    private GameMode _currentSelectedGameMode;
    private int _minBallsCount = Constants.BallsCount;

    public int BallsCountOnLevel => int.Parse(_inputField.text);

    public event Action StartGameButtonPressed;
    public event Action<GameMode> GameModeSelected;

    [Inject]
    public void Construct(IReadOnlyCollection<GameMode> gameModes)
    {
        Debug.Log("SelectGameModeMenu");

        int index = -1;

        foreach (GameMode gameMode in gameModes)
        {
            _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData(gameMode.Target));
            _gameModesMap.Add(++index, gameMode);
        }

        _inputField.text = _minBallsCount.ToString();
        _gameModesDropdown.captionText.text = "Выберите режим";
        _startGameButton.interactable = false;

        _gameModesDropdown.onValueChanged.AddListener(OnGameModeSelected);
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        _inputField.onEndEdit.AddListener(OnInputFieldValueChanged);
    }

    private void OnDestroy()
    {
        _gameModesDropdown.onValueChanged.RemoveListener(OnGameModeSelected);
        _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
        _inputField.onEndEdit.RemoveListener(OnInputFieldValueChanged);
    }

    private void OnGameModeSelected(int index)
    {
        _startGameButton.interactable = true;
        _currentSelectedGameMode = _gameModesMap[index];

        GameModeSelected?.Invoke(_currentSelectedGameMode);
    }

    private void OnStartGameButtonClicked()
    {
        StartGameButtonPressed?.Invoke();
    }

    private void OnInputFieldValueChanged(string newValue)
    {
        if (int.TryParse(newValue, out int result))
        {
            if (result < _minBallsCount)
                _inputField.text = _minBallsCount.ToString();
        }
        else
        {
            _inputField.text = _minBallsCount.ToString();
        }
    }
}
