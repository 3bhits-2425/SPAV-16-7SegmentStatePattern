public class State4 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 4;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State3();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State5();
    }
}
