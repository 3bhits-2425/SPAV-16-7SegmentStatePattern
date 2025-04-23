public class State9 : ISevenSegmentDisplayState
{
    public int GetDigit()
    {
        return 9;
    }

    public ISevenSegmentDisplayState CountDown()
    {
        return new State8();
    }

    public ISevenSegmentDisplayState CountUp()
    {
        return new State0(); 
    }
}
