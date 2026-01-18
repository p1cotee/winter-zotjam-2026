using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public bool isSnapped = false;
    private PuzzleContainer parentContainer;

    void Start() {
        parentContainer = GetComponentInParent<PuzzleContainer>();
    }

    public void SnapIntoPlace() {
        isSnapped = true;
        // Tell the container to check if the whole puzzle is done
        parentContainer.CheckCompletion();
    }
}