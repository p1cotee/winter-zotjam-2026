using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public int puzzlesFinished = 0;
    public int totalPuzzles = 5;

    [Header("Audio")]
    public AudioClip puzzleCompleteSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPuzzleFinished(PuzzleContainer completedPuzzle) {
        puzzlesFinished++;
        if (puzzleCompleteSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(puzzleCompleteSound);
        }
        Debug.Log($"Puzzle {completedPuzzle.name} completed! Total: {puzzlesFinished}/{totalPuzzles}");

        if (puzzlesFinished >= totalPuzzles) {
            // FINALLY, notify the Game Manager
            Debug.Log("Notify Game Manager");
    		SceneManager.LoadScene("EndScene");

            //GameManager.Instance.HandleAllPuzzlesClear();
        }
    }
}