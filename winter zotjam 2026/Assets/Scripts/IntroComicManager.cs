using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroComicManager : MonoBehaviour
{
    public GameObject introComic;

    public AudioClip[] lines;
    private AudioSource audioSource;
    
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        introComic.transform.position = new Vector3(14.22f, -10.58f, 0);
        introComic.transform.localScale = new Vector3(2.8f, 2.8f, 1);
        StartCoroutine(playIntroComic());
    }

    IEnumerator waitThenPan(Vector3 scale, int pauseSeconds, Vector3 targetPos, float panningTime)
    {

        Vector3 startPos = introComic.transform.position;
        introComic.transform.localScale = scale;
        float elapsed = 0f;

        while(elapsed < panningTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / panningTime;
            introComic.transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }
        introComic.transform.position = targetPos;

        yield return new WaitForSeconds(pauseSeconds);
    }

    IEnumerator playIntroComic()
    {
        Vector3 endPos1 = new Vector3(14.22f, 11.13f, 0f);
        Vector3 scale1 = new Vector3(2.8f, 2.8f, 1);

        Vector3 endPos2 = new Vector3(-1.79f, -13.99f, 0f);
        Vector3 scale2 = new Vector3(3.3f, 3.3f, 1);
        
        Vector3 endPos3 = new Vector3(-1.79f, -9.39f, 0f);
        Vector3 endPos4 = new Vector3(-1.79f, -4.57f, 0f);
        Vector3 endPos5 = new Vector3(-1.79f, 2.11f, 0f);
        Vector3 endPos6 = new Vector3(-1.79f, 9.84f, 0f);

        Vector3 scale3 = new Vector3(2.85f, 2.85f, 1);
        Vector3 endPos7 = new Vector3(-13.84f, -11f, 0f);
        Vector3 endPos8 = new Vector3(-13.84f, -4.3f, 0f);
        Vector3 endPos9 = new Vector3(-13.84f, 7.82f, 0f);

        
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(lines[0]);
        
        yield return StartCoroutine(
            
            waitThenPan(scale1, 0, endPos1, 3)
        );

        audioSource.PlayOneShot(lines[1]);
        yield return StartCoroutine(
            waitThenPan(scale2, 7, endPos2, 1)
        );

        StartCoroutine(playAudio(new AudioClip[] { lines[2], lines[3], lines[4] }));
        yield return StartCoroutine(
            waitThenPan(scale2, 12, endPos3, 1)
        );
        
        audioSource.PlayOneShot(lines[5]);
        yield return StartCoroutine(
            waitThenPan(scale2, 4, endPos4, 1)
        );

        audioSource.PlayOneShot(lines[6]);
        yield return StartCoroutine(
            waitThenPan(scale2, 7, endPos5, 1)
        );

        yield return StartCoroutine(
            waitThenPan(scale2, 1, endPos6, 1)
        );

        audioSource.PlayOneShot(lines[7]);
        yield return StartCoroutine(
            waitThenPan(scale3, 5, endPos7, 1)
        );

        audioSource.PlayOneShot(lines[8]);
        yield return StartCoroutine(
            waitThenPan(scale3, 5, endPos8, 1)
        );

        StartCoroutine(playAudio(new AudioClip[] {lines[9], lines[10] }));
        yield return StartCoroutine(
            waitThenPan(scale3, 7, endPos9, 8)
        );

        SceneManager.LoadScene("Tutorial");
    }

    IEnumerator playAudio(AudioClip[] clips)
    {
        foreach (AudioClip clip in clips)
        {
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
                yield return new WaitForSeconds(clip.length);
            }
        }
    }
}