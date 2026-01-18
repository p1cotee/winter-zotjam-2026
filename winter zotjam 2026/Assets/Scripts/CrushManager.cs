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
    public bool isLookingAtPlayer = false;

    

    void Awake()
    {
        sr = crush.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(randomTurnArounds());
    }

    void Update()
    {
        if(Player.Instance != null)
        {
            int totalBlinks = Player.Instance.blinkCount;
        }
    }

    IEnumerator randomTurnArounds()
    {
        while (true){
            
            waitTime = Random.Range(15f, 20f);
            if(Player.Instance.blinkCount > 5 && Player.Instance.blinkCount < 10)
            {
                waitTime = Random.Range(10f, 15f); //faster waittime
            }
            else if(Player.Instance.blinkCount > 10)
            {
                waitTime = Random.Range(5f, 10f);
            }
            
            yield return new WaitForSeconds(waitTime);

            sr.sprite = crushLookingAtPlayer;
            isLookingAtPlayer = true;
            Player.Instance.GotCaught(isLookingAtPlayer);

            yield return new WaitForSeconds(3f);
            sr.sprite = crushLookingAway;
            isLookingAtPlayer = false;
        }
    }
}
