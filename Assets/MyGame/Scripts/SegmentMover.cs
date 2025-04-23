using UnityEngine;

public class SegmentMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;     // Geschwindigkeit des Ein-/Ausfahrens

    private Vector3 extendedPosition;  // Position, Segment sichtbar
    private Vector3 retractedPosition;   // Position, Segment versteckt
    private Vector3 targetPosition;  // Aktuelles Ziel der Bewegung

    private float lerpFactor = 0f;   // Fortschritt der Lerp-Bewegung

    private void Awake()
    {
        extendedPosition = retractedPosition = transform.localPosition;
    }

    //Segment wird ausgefahren
    public void SetExtendedPosition(float zPos) 
    {
        extendedPosition = new Vector3(extendedPosition.x, extendedPosition.y, zPos);
    }

    // Segment wird eingefahren
    public void SetHiddenPosZ(float zPos) 
    {
        retractedPosition = new Vector3(retractedPosition.x, retractedPosition.y, zPos);
    }

    public void ResetSegment()
    {
        ExtendSegment(true);
    }

    public void ExtendSegment(bool isVisible)
    {
        targetPosition = isVisible ? extendedPosition : retractedPosition;
        lerpFactor = 0f; // Zurücksetzen der Lerp-Animation
    }

    private void Update()
    {
        lerpFactor += Mathf.Clamp01(moveSpeed * Time.deltaTime); // Zeitbasiertes Lerp
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, lerpFactor);
    }
}
