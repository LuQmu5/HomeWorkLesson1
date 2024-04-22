using System;

public class PlayerReputation
{
    private int _currentReputation;

    public int CurrentReputation => _currentReputation;

    public event Action<int> ReputationChanged;

    public void IncreaseReputation(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException("Value can't be negative");

        _currentReputation += value;

        ReputationChanged?.Invoke(_currentReputation);
    }
}
