
public interface ISevenSegmentDisplayState 
{
    // get the Number for the current state
    public int GetDigit();
    // switch to the next state
    //count down
    public ISevenSegmentDisplayState CountDown();

    //count up
    public ISevenSegmentDisplayState CountUp();

    // state 0

}
