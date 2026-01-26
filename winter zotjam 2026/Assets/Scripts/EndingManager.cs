using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
	public void OnHomeClick() {
		SceneManager.LoadScene("TitleScreen");
	}

	public void OnClick() {
        SceneManager.LoadScene("Tutorial");
	}
}
