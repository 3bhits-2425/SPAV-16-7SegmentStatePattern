using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private const float CoundownDuration = 3f;

    [SerializeField] private Toggle toggleInstantStart;
    [SerializeField] private Toggle toggleDelayedStart;
    [SerializeField] private Button btnStart, btnReset;
    [SerializeField] private TMP_Text instruction, timerText;
    
    private SevenSegmentDisplay segmentDisplay;

    private void Start()
    {
        InitializeUI();
    }

    //called via inspector Reset Btn
    public void Reset()
    {
        InitializeUI();

        segmentDisplay.ResetSegmentDisplay();
        segmentDisplay.RotateDisplay();
    }

    //called via inspector Start Btn
    public void ActivateSegement()
    {
        btnStart.interactable = false;
        toggleInstantStart.interactable = false;
        toggleDelayedStart.interactable = false;

        if (toggleInstantStart.isOn)
        {
            StartDisplay();
        }
        else if (toggleDelayedStart.isOn)
        {
            StartCoroutine(StartWithDelay(3f)); // Timer starten
        }
    }

    public void InitializeUI()
    {
        instruction.gameObject.SetActive(false);
        btnReset.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);

        btnStart.interactable = true;
        toggleInstantStart.interactable = true;
        toggleDelayedStart.interactable = true;
    }

    public void SetDisplay(SevenSegmentDisplay display)
    {
        segmentDisplay = display;
    }

    // Sofort starten
    private void StartDisplay()
    {
        segmentDisplay.ActivateSegment(); 
        instruction.gameObject.SetActive(true);
    }

    public void ActivateResetBtn(bool activate)
    {
        btnReset.gameObject.SetActive(activate);
    }

    public void DeactivateInstruction()
    {
        instruction.gameObject.SetActive(false);
    }

    IEnumerator StartWithDelay(float delay)
    {
        StartCoroutine(StartCountdown(delay));
        yield return new WaitForSeconds(delay); // Warten, ohne `Update()` zu belasten
        timerText.gameObject.SetActive(false);
        StartDisplay();
    }

    IEnumerator StartCountdown(float duration = CoundownDuration)
    {
        timerText.gameObject.SetActive(true);

        for (int i = (int)duration; i > 0; i--)
        {
            timerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        timerText.gameObject.SetActive(false);
    }
}
