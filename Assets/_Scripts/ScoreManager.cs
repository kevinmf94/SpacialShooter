public class ScoreManager : Singleton<ScoreManager>
{

    private int _amount = 0;

    public int Amount
    {
        get => _amount;
        set => _amount = value;
    }

}
