using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseQuestPanelDisplay : MonoBehaviour
{
    [SerializeField] private QuestTracker _questTracker;

    [Header("UI")]
    [SerializeField] private Button _chooseAllButton;
    [SerializeField] private Button _chooseRandomButton;

    private void OnEnable()
    {
        _chooseAllButton.onClick.AddListener(ChooseAllButtonClicked);
        _chooseRandomButton.onClick.AddListener(ChooseRandomButtonClicked);
    }

    private void OnDisable()
    {
        _chooseAllButton.onClick.RemoveListener(ChooseAllButtonClicked);
        _chooseRandomButton.onClick.RemoveListener(ChooseRandomButtonClicked);
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void ChooseAllButtonClicked()
    {
        _questTracker.SetDestroyAllQuest();
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ChooseRandomButtonClicked()
    {
        _questTracker.SetDestroyRandomQuest();
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
