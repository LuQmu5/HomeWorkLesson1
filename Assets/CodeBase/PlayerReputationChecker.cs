public class PlayerReputationChecker
{
    private PlayerReputation _playerReputation;

    public PlayerReputationChecker(PlayerReputation playerReputation)
    {
        _playerReputation = playerReputation;
    }

    public bool IsReputationEnough(int requiredReputation)
    {
        if (requiredReputation < 0)
            throw new System.ArgumentOutOfRangeException("can't be less than zero");

        return _playerReputation.CurrentReputation >= requiredReputation;
    }
}
