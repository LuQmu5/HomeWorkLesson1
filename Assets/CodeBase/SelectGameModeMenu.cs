using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameModeMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _gameModesDropdown;

    private Dictionary<int, GameMode> _gameModesMap = new Dictionary<int, GameMode>();

    public void Init(IReadOnlyCollection<GameMode> gameModes)
    {
        int index = -1;

        foreach (GameMode gameMode in gameModes)
        {
            _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData(gameMode.Target));
            _gameModesMap.Add(++index, gameMode);
        }

        _gameModesDropdown.onValueChanged.AddListener(OnGameModeSelected);
    }

    private void OnDestroy()
    {
        _gameModesDropdown.onValueChanged.RemoveListener(OnGameModeSelected);
    }

    private void OnGameModeSelected(int index)
    {
        print(_gameModesMap[index].Target);
    }
}
