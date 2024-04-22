using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameModeMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _gameModesDropdown;
    [SerializeField] private Button _startGameButton;

    private Dictionary<int, GameMode> _gameModesMap = new Dictionary<int, GameMode>();
    private GameMode _currentSelectedGameMode;

    public event Action<GameMode> StartGameButtonPressed;

    public void Init(IReadOnlyCollection<GameMode> gameModes)
    {
        int index = -1;

        foreach (GameMode gameMode in gameModes)
        {
            _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData(gameMode.Target));
            _gameModesMap.Add(++index, gameMode);
        }

        _gameModesDropdown.captionText.text = "Выбрать...";
        _startGameButton.interactable = false;

        _gameModesDropdown.onValueChanged.AddListener(OnGameModeSelected);
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
    }

    private void OnDestroy()
    {
        _gameModesDropdown.onValueChanged.RemoveListener(OnGameModeSelected);
        _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
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
}
