using UnityEngine;

public class BlinkCounter : MonoBehaviour
{
    public int blinkCount = 0;
    private Player _player => Player.Instance; //makes the singleton call shorter i guess

    void Start()
    {
        if (Player.Instance == null) return;
        _player.OnBlink += BlinkCount;
        
    }
    public void OnEnable()//dont use this
    {
        
    }

    public void OnDisable()
    {
        _player.OnBlink -= BlinkCount;
    }

    private void BlinkCount()
    {
        blinkCount += 1;
        Debug.Log("blink count: " + blinkCount);
    }
}
