using UnityEngine;
using System.Collections;

public class SevenSegmentDisplay : MonoBehaviour
{
    [SerializeField] private float extendedYPostion = -0.7f;
    [SerializeField] private float retractedYPosition = 0f;
    [SerializeField] private float rotationSpeed = 200f;

    private SegmentMover[] segments;

    public bool allOn = false;
    public bool isNumberSet = false;

    public bool isActive = true;
    private bool isRotating = false;

    // Zweidimensionales Array - Direktes Mapping:
    // Jede Zeile ist eine Zahl (0-9), jedes Element ein Segment (A-G)
    private bool[,] numberPatterns =
    {
        { true,  true,  true,  true,  true,  true,  false }, // 0 
        { false, true,  true,  false, false, false, false }, // 1 
        { true,  true,  false, true,  true,  false, true  }, // 2 
        { true,  true,  true,  true,  false, false, true  }, // 3 
        { false, true,  true,  false, false, true,  true  }, // 4 
        { true,  false, true,  true,  false, true,  true  }, // 5 
        { true,  false, true,  true,  true,  true,  true  }, // 6 
        { true,  true,  true,  false, false, false, false }, // 7 
        { true,  true,  true,  true,  true,  true,  true  }, // 8 
        { true,  true,  true,  false, false, true,  true  }  // 9
    };

    private void Awake()
    {
        segments = GetComponentsInChildren<SegmentMover>();
    }

    private void Start()
    {
        DeactivateSegment();
        SetPosition();
        AllSegmentON();
    }

    private IEnumerator RotateSmoothly(float targetAngle)
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, transform.eulerAngles.y + targetAngle, 0);

        while (Quaternion.Angle(transform.rotation, endRotation) > 0.1f)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation, step);
            yield return null;
        }

        transform.rotation = endRotation; // Sicherstellen, dass genau die Endposition erreicht wird
        isRotating = false;
        isActive = IsActive();
    }

    public void ActivateSegment()
    {
        if (isRotating) return;
        
        StartCoroutine(RotateSmoothly(180));
    }

    public bool IsActive()
    {
       return Mathf.RoundToInt(gameObject.transform.localEulerAngles.y) == 0f ? true : false;
      
    }

    public void DeactivateSegment()
    {
        if (IsActive())
        {
            StartCoroutine(RotateSmoothly(180));
        }
    }

    public void ExtendSegmentsFor(int number)
    {
        if (number < 0 || number > 9) return; // Card Clause; Early Return: Nur Zahlen 0–9 zulassen

        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].ExtendSegment(numberPatterns[number, i]); // Segmente ausfahren oder einfahren
        }

        //isNumberSet = true;
    }

    private void SetPosition()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].SetExtendedPosition(extendedYPostion);
            segments[i].SetHiddenPosZ(retractedYPosition);
        }
    }

    public void ResetSegmentDisplay()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].ResetSegment();
        }

        isNumberSet = false;
    }

    public void RotateDisplay()
    {
        StartCoroutine(RotateSmoothly(180));
    }

    public void AllSegmentON()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].ExtendSegment(true);
        }
    }
}
