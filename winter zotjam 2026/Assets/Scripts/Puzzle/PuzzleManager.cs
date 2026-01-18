using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int puzzlesFinished = 0;
    public int totalPuzzles = 5;

    public void OnPuzzleFinished(PuzzleContainer completedPuzzle) {
        puzzlesFinished++;
        Debug.Log($"Puzzle {completedPuzzle.name} completed! Total: {puzzlesFinished}/{totalPuzzles}");

        if (puzzlesFinished >= totalPuzzles) {
            // FINALLY, notify the Game Manager
            Debug.Log("Notify Game Manager");
            //GameManager.Instance.HandleAllPuzzlesClear();
        }
    }
}