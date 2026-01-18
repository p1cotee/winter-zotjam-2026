using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering;

public class CrushManager : MonoBehaviour
{
    public Sprite crushLookingAway;
    public Sprite crushLookingAtPlayer;
    public GameObject crush;
    SpriteRenderer sr;
    public float waitTime;

    void Awake()
    {
        sr = crush.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(randomTurnArounds());
    }
    
    IEnumerator randomTurnArounds()
    {
        while (true){
            waitTime = Random.Range(1f, 5f);
            yield return new WaitForSeconds(waitTime);

            sr.sprite = crushLookingAtPlayer;

            yield return new WaitForSeconds(3f);
            sr.sprite = crushLookingAway;
        }
    }
}
