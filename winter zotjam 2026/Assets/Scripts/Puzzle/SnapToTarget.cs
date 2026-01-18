using UnityEngine;

public class SnapToTarget : MonoBehaviour
{
    public Transform targetPoint;
    public float snapDistance = 0.5f;

    private Vector3 offset;
    private bool isSnapped = false;

    private PuzzlePiece puzzlePiece;

    void Start() {
        puzzlePiece = GetComponent<PuzzlePiece>();
    }

    void OnMouseDown()
    {
        if (isSnapped) return;

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
            return; 
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
