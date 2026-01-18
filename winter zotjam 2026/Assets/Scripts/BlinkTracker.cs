using UnityEngine;

public class BlinkTracker : MonoBehaviour
{
    private void OnEnable()
    {
        if (Player.Instance != null)
        {
            Player.Instance.OnBlink += TrackBlink;
        }
    }

    private void OnDisable()
    {
        if (Player.Instance != null)
        {
            Player.Instance.OnBlink -= TrackBlink;
        }
    }

    private void TrackBlink()
    {
        int totalBlinks = Player.Instance.blinkCount;
        Debug.Log("total blinks: " + totalBlinks);
    }
}
