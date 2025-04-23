public class State5 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 5;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State4();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State6();
    }
}
