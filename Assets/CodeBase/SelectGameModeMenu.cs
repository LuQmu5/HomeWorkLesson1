using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameModeMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _gameModesDropdown;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private TMP_InputField _inputField;

    private Dictionary<int, GameMode> _gameModesMap = new Dictionary<int, GameMode>();
    private GameMode _currentSelectedGameMode;
    private int _minBallsCount;

    public int BallsCountOnLevel => int.Parse(_inputField.text);

    public event Action<GameMode> StartGameButtonPressed;

    public void Init(IReadOnlyCollection<GameMode> gameModes, int minBallsCount)
    {
        _minBallsCount = minBallsCount;
        int index = -1;

        foreach (GameMode gameMode in gameModes)
        {
            _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData(gameMode.Target));
            _gameModesMap.Add(++index, gameMode);
        }

        _inputField.text = _minBallsCount.ToString();
        _gameModesDropdown.captionText.text = "Выбрать...";
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
    }

    private void OnStartGameButtonClicked()
    {
        StartGameButtonPressed?.Invoke(_currentSelectedGameMode);
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
