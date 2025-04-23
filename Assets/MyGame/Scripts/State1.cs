
public class State1 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 1;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State0();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State2();
    }
}
