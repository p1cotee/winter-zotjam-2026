using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private float _musicVolume = 1f;

    [SerializeField] private AudioSource _schoolBellSfx;
    
    void Start()
    {
        _backgroundMusic.volume = _musicVolume;
        StartCoroutine(PlaySchoolBellAfterDelay(2f));
        
    }

    IEnumerator PlaySchoolBellAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _schoolBellSfx.Play();

        yield return new WaitForSeconds(_schoolBellSfx.clip.length);
        _backgroundMusic.Play();
    }
}
