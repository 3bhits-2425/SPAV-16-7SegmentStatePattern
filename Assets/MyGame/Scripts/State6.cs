public class State6 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 6;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State5();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State7();
    }
}
