using UnityEngine;

public class SnapToTarget : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip snapSound;
    private AudioSource audioSource;

    [Header("Bobbing Settings")]
    public bool useBobbing = true;
    public float bobSpeed = 2f;    // How fast it moves up and down
    public float bobHeight = 0.2f; // How far it moves from its start point
    public float bobWidth = 0.3f;
    public float horizontalSpeedMult = 0.7f;

    private Vector3 startPos;
    private bool isDragging = false;

    public Transform targetPoint;
    public float snapDistance = 0.5f;

    private Vector3 offset;
    private bool isSnapped = false;

    private PuzzlePiece puzzlePiece;

    void Start() {
        puzzlePiece = GetComponent<PuzzlePiece>();
        startPos = transform.position;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (useBobbing && !isDragging && !isSnapped)
        {
            float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            float newX = startPos.x + Mathf.Sin(Time.time * (bobSpeed * horizontalSpeedMult)) * bobWidth;
            transform.position = new Vector3(newX, newY, startPos.z);
        }
    }

    void OnMouseDown()
    {
        if (isSnapped) return;
        isDragging = true;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z;
        offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
        if (isSnapped) return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z;
        transform.position = mouseWorldPos + offset;

        if (Vector2.Distance(transform.position, targetPoint.position) <= snapDistance)
        {
            isSnapped = true;
            if (puzzlePiece != null)
            {
                puzzlePiece.SnapIntoPlace();
            }
            Debug.Log("SNAPPED");
            if (snapSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(snapSound);
            }
            return; 
        }
    }
    void OnMouseUp()
    {
        isDragging = false;
        
        // If it didn't snap, reset startPos to the new drop location 
        // so it bobs where the player left it.
        if (!isSnapped)
        {
            startPos = transform.position;
        }
    }

    void LateUpdate()
    {
        if (isSnapped)
        {
            transform.position = targetPoint.position; 
        }
    }

    void OnDrawGizmos()
    {
        if (targetPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(targetPoint.position, snapDistance);
        }
    }
}
