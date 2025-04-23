public class State7 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 7;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State6();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State8();
    }
}
