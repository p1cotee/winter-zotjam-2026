using UnityEngine;

public class BlinkCounter : MonoBehaviour
{
    public int blinkCount = 0;
    public Player player;

    public void OnEnable()
    {
        player.OnBlink += BlinkCount;
    }

    public void OnDisable()
    {
        player.OnBlink -= BlinkCount;
    }

    private void BlinkCount()
    {
        blinkCount += 1;
        Debug.Log("blink count: " + blinkCount);
    }
}
