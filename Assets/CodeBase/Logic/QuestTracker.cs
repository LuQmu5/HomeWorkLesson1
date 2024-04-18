using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentTargetText;

    [SerializeField] private DestroyableBall[] _whiteBalls;
    [SerializeField] private DestroyableBall[] _redBalls;
    [SerializeField] private DestroyableBall[] _greenBalls;

    private List<DestroyableBall> _currentTargets = new List<DestroyableBall>();

    private void OnEnable()
    {
        DestroyableBall.Destroyed += OnBallDestroyed;
    }

    private void OnDisable()
    {
        DestroyableBall.Destroyed -= OnBallDestroyed;
    }

    public void SetDestroyAllQuest()
    {
        _currentTargets.AddRange(_whiteBalls);
        _currentTargets.AddRange(_redBalls);
        _currentTargets.AddRange(_greenBalls);

        _currentTargetText.text += " All";
    }

    public void SetDestroyRandomQuest()
    {
        int randomChoice = Random.Range(0, 3);

        if (randomChoice == 0)
        {
            _currentTargets.AddRange(_whiteBalls);
            _currentTargetText.text += " White";
        }
        else if (randomChoice == 1)
        {
            _currentTargets.AddRange(_redBalls);
            _currentTargetText.text += " Red";
        }
        else
        {
            _currentTargets.AddRange(_greenBalls);
            _currentTargetText.text += " Green";
        }
    }

    private void OnBallDestroyed(DestroyableBall destroyedBall)
    {
        if (_currentTargets.Contains(destroyedBall))
        {
            _currentTargets.Remove(destroyedBall);

            if (_currentTargets.Count == 0)
            {
                Debug.Log("WIN!");
                Time.timeScale = 0;
            }
        }
        else
        {
            Debug.Log("Lose...");
            Time.timeScale = 0;
        }
    }
}
