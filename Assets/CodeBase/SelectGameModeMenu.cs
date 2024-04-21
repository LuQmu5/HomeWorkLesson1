using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameModeMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _gameModesDropdown;

    public void Init()
    {
        _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData("test1"));
        _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData("test2"));
        _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData("test3"));
        _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData("test4"));
        _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData("test5"));
        _gameModesDropdown.options.Add(new TMP_Dropdown.OptionData("test6"));
    }
}
