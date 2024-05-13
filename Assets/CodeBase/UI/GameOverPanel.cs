using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _header;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    public event Action RestartButtonClicked;
    public event Action ExitButtonClicked;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        _exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public void SetHeader(string text)
    {
        _header.text = text;
    }

    private void OnRestartButtonClicked()
    {
        RestartButtonClicked?.Invoke();
    }

    private void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }
}
