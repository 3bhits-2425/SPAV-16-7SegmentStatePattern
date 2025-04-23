public class State8 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 8;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State7();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State9();
    }
}
