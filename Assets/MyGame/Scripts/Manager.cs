using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private SevenSegmentDisplay myDigit;
    private UIManager myUIManager;

    private const int MinDigit = 0;
    private const int MaxDigit = 9;

    // save state of the seven segment 
    private ISevenSegmentDisplayState myDisplayState;
    private void Start()
    {
        

        if (myDigit == null)
        {
            Debug.LogWarning($"In Component `{GetType().Name}` attached to GameObject `{gameObject.name}`, " +
                             $"the object `{nameof(myUIManager)}` was not assigned in the inspector!", this);
            return;
        }

        myUIManager = GetComponent<UIManager>();

        if (myUIManager == null)
        {
            Debug.LogWarning($"In Component `{GetType().Name}` attached to GameObject `{gameObject.name}`, " +
                             $"the object `{nameof(myUIManager)}` was not assigned in the script!", this);
            return;
        }

        myUIManager.SetDisplay(myDigit);
        myDigit.ResetSegmentDisplay();

        // initialize segment state
        myDisplayState = new State0();
        
    }

    private void Update()
    {
        if (myDigit == null) return;
        if (!myDigit.isActive) return;
        ///if (myDigit.isNumberSet) return;
        HandleDigitInput(myDisplayState.GetDigit());
        // implement mechanic
        // counting up?
        if (IsPlusPressed())
        {
            // we are counting up
            myDisplayState = myDisplayState.CountUp();
            // display the current state
            HandleDigitInput(myDisplayState.GetDigit());
        }

        //for (int i = MinDigit; i <= MaxDigit; i++)
        //{
        //    if (IsDigitPressed(i))
        //    {
        //      HandleDigitInput(i);
        //        break;
        //   }
        //}

        // counting down?
        if (IsMinusPressed())
        {
            myDisplayState = myDisplayState.CountDown();
            // display the current state
            HandleDigitInput(myDisplayState.GetDigit());
        }
    }

    private void HandleDigitInput(int digit)
    {
        myDigit.isNumberSet = true;

        myDigit.ExtendSegmentsFor(digit);
        myUIManager.DeactivateInstruction();
        myUIManager.ActivateResetBtn(true);
    }

    private bool IsPlusPressed()
    {
        return Input.GetKeyDown(KeyCode.Keypad6) ||      
               Input.GetKeyDown(KeyCode.RightArrow);     
    }

    private bool IsMinusPressed()
    {
        return Input.GetKeyDown(KeyCode.Keypad4) ||      
               Input.GetKeyDown(KeyCode.LeftArrow);      
    }


    private bool IsDigitPressed(int i)
    {
        return Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)) ||
               Input.GetKeyDown((KeyCode)((int)KeyCode.Keypad0 + i));
    }
}
