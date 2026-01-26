using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class CrushManager : MonoBehaviour
{
    public Sprite crushLookingAway;
    public Sprite crushLookingAtPlayer;
    public Sprite crushAboutToTurn;
    public GameObject crush;
    SpriteRenderer sr;
    public float waitTime;
    public bool isLookingAtPlayer = false;

    [SerializeField] AudioSource _sparkleSfx;
    [SerializeField] AudioSource _turnWarning;

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
            float turnPauseTime = 2f;
            if(Player.Instance.blinkCount > 3 && Player.Instance.blinkCount < 7)
            {
                waitTime = Random.Range(10f, 15f); //faster waittime
                turnPauseTime = 1.5f;
            }
            else if(Player.Instance.blinkCount > 7)
            {
                waitTime = Random.Range(5f, 10f);
                turnPauseTime = 1f;
            }
            
            yield return new WaitForSeconds(waitTime);
            sr.sprite = crushAboutToTurn;
            //play sfx
            _turnWarning.Play();

            yield return new WaitForSeconds(turnPauseTime);
            sr.sprite = crushLookingAtPlayer;
            isLookingAtPlayer = true;
            //Player.Instance.GotCaught(isLookingAtPlayer);
            //play sparkle sfx
            _sparkleSfx.Play();


            yield return new WaitForSeconds(3f);
            sr.sprite = crushLookingAway;
            isLookingAtPlayer = false;
            
        }
    }
}
