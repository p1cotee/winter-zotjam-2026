using UnityEngine;
using UnityEngine.SceneManagement; // Required for switching scenes

public class TutorialManager : MonoBehaviour
{
    [Header("Settings")]
    public string nextSceneName; // Type the name of your game scene here

    void Update()
    {
        // Check if the Space bar was pressed this frame
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Double check that a scene name was actually provided
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("No scene name provided in the Inspector!");
        }
    }
}