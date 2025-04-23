public class State3 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 3;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State2();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State4();
    }
}
