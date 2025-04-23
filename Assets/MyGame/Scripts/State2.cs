
public class State2 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 2;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State1();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State3();
    }
}
