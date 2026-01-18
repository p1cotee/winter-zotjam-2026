using UnityEngine;

public class TasklistManager : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public GameObject[] crossoutLines;
    void Start()
    {
        
    }

    void Update()
    {
        if(puzzleManager.puzzlesFinished == 1)
        {
            crossoutLines[0].SetActive(true);
        }

        if(puzzleManager.puzzlesFinished == 2)
        {
            crossoutLines[1].SetActive(true);
        }

        if(puzzleManager.puzzlesFinished == 3)
        {
            crossoutLines[2].SetActive(true);
        }

        if(puzzleManager.puzzlesFinished == 4)
        {
            crossoutLines[2].SetActive(true);
        }

        if(puzzleManager.puzzlesFinished == 5)
        {
            crossoutLines[3].SetActive(true);
        }
    }
}
