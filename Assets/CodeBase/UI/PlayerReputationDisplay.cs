using TMPro;
using UnityEngine;

public class PlayerReputationDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private PlayerReputation _playerReputation;

    public void Construct(PlayerReputation playerReputation)
    {
        _playerReputation = playerReputation;

        playerReputation.ReputationChanged += OnPlayerReputationChanged;
    }

    private void OnDestroy()
    {
        _playerReputation.ReputationChanged -= OnPlayerReputationChanged;
    }

    private void OnPlayerReputationChanged(int value)
    {
        _text.text = "Current Reputation: " + value;
    }
}