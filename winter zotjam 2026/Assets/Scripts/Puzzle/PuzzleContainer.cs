using UnityEngine;
using System.Collections; // Required for Coroutines

public class PuzzleContainer : MonoBehaviour
{
    public bool isComplete = false;
    public int amtPieces = 9;
    private PuzzlePiece[] allPieces;
    private PuzzleManager puzzleManager;

    [Header("Transition Settings")]
    public GameObject completionImage; // The jigsaw image to show
    public GameObject nextPuzzle;      // The next puzzle to load
    public float displayTime = 2.0f;   // How long to wait

    void Awake() {
        allPieces = GetComponentsInChildren<PuzzlePiece>();
        puzzleManager = Object.FindFirstObjectByType<PuzzleManager>();
        
        // Ensure the completion image starts hidden
        if(completionImage != null) completionImage.SetActive(false);
    }

    public void CheckCompletion() {
        if (isComplete) return;

        int snapCount = 0;
        foreach (var piece in allPieces) {
            if (piece != null && piece.isSnapped) snapCount++;
        }

        if (snapCount >= amtPieces) {
            isComplete = true;
            // Start the Coroutine instead of running logic immediately
            StartCoroutine(CompleteAndTransition());
        }
    }

    IEnumerator CompleteAndTransition() {
        Debug.Log("Puzzle Complete! Showing image...");

        // 1. Show the jigsaw image
        if (completionImage != null) completionImage.SetActive(true);

        // 2. Notify the manager immediately (so it can track progress)
        if (puzzleManager != null) puzzleManager.OnPuzzleFinished(this);

        // 3. Wait for 2 seconds
        yield return new WaitForSeconds(displayTime);

        // 4. Swap the puzzles
        if (nextPuzzle != null) nextPuzzle.SetActive(true);

        if(nextPuzzle == null) yield return new WaitForSeconds(displayTime);
        
        // Disable this current puzzle object
        completionImage.SetActive(false);
        this.gameObject.SetActive(false);
    }
}