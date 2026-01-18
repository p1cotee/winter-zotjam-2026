using System.Collections;
using UnityEngine;

public class IntroComicManager : MonoBehaviour
{
    public GameObject introComic;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        introComic.transform.position = new Vector3(14.22f, -11.08f, 0);
        introComic.transform.localScale = new Vector3(2.8f, 2.8f, 1);
        StartCoroutine(playIntroComic());
    }

    /*void panToNextPanel(int pauseTime, int panelNumber)
    {
        if(panelNumber == 1)
        {
            Vector3 endPos1 = new Vector3(14.22f, 11.13f, 0f);
            Vector3 scale1 = new Vector3(2.8f, 2.8f, 1);
            StartCoroutine(waitThenPan(scale1, pauseTime, endPos1, 5f));
        }
        if(panelNumber == 2)
        {
            Vector3 endPos2 = new Vector3(-0.74f, -13.99f, 0f);
            Vector3 scale2 = new Vector3(3.1f, 3.1f, 1);
            StartCoroutine(waitThenPan(scale2, pauseTime, endPos2, 5f));
        }
    }*/

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

        Vector3 endPos2 = new Vector3(-0.74f, -13.99f, 0f);
        Vector3 scale2 = new Vector3(3.3f, 3.3f, 1);
        
        Vector3 endPos3 = new Vector3(-0.74f, -10.46f, 0f);
        Vector3 endPos4 = new Vector3(-0.74f, -3.2f, 0f);
        Vector3 endPos5 = new Vector3(-0.74f, 3.87f, 0f);
        Vector3 endPos6 = new Vector3(-0.74f, 12.5f, 0f);

        Vector3 scale3 = new Vector3(2.85f, 2.85f, 1);
        Vector3 endPos7 = new Vector3(-14.6f, -11f, 0f);
        Vector3 endPos8 = new Vector3(-14.6f, -3.08f, 0f);
        Vector3 endPos9 = new Vector3(-14.6f, 10.41f, 0f);

        yield return StartCoroutine(
            waitThenPan(scale1, 1, endPos1, 3)
        );

        yield return StartCoroutine(
            waitThenPan(scale2, 1, endPos2, 1)
        );

        yield return StartCoroutine(
            waitThenPan(scale2, 1, endPos3, 1)
        );

        yield return StartCoroutine(
            waitThenPan(scale2, 1, endPos4, 1)
        );

        yield return StartCoroutine(
            waitThenPan(scale2, 1, endPos5, 1)
        );

        yield return StartCoroutine(
            waitThenPan(scale2, 1, endPos6, 1)
        );

        yield return StartCoroutine(
            waitThenPan(scale3, 1, endPos7, 1)
        );

        yield return StartCoroutine(
            waitThenPan(scale3, 1, endPos8, 1)
        );

        yield return StartCoroutine(
            waitThenPan(scale3, 1, endPos9, 1)
        );
    }
}