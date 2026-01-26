using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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

            //trying some tweening shaking
            completedPuzzle.completionImage.transform.DOShakeScale(1f, .1f);
            completedPuzzle.completionImage.transform.DOMove(
                new Vector3(0, completedPuzzle.completionImage.transform.position.y, 0), 1f);
            completedPuzzle.completionImage.transform.DOMove(
                new Vector3(-15, completedPuzzle.completionImage.transform.position.y, 0), 1f);
        }
        Debug.Log($"Puzzle {completedPuzzle.name} completed! Total: {puzzlesFinished}/{totalPuzzles}");

        if (puzzlesFinished >= totalPuzzles) {
            // FINALLY, notify the Game Manager
            Debug.Log("Notify Game Manager");
    		SceneManager.LoadScene("GoodEnding");

            //GameManager.Instance.HandleAllPuzzlesClear();
        }
    }
}