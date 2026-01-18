using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoveringMovement : MonoBehaviour
{
    public GameObject biggerTasklist;
    private float offset = 0.5f;
    private float speed = 10f;

    Vector3 originalPosition = new Vector3(-4.33f, -4.76f, 0);
    Vector3 targetPosition;
    Vector3 bigTarget = new Vector3(-0.35f, -4.2f, 0);

    Vector3 offScreen = new Vector3(-4.33f, -10.42f, 0);
    Vector3 bigOffScreen = new Vector3(-0.35f, -14.52f, 0);
    bool isOffScreen = false;
    bool showBigList = false;

    AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        targetPosition = originalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        if(showBigList)
        {
            biggerTasklist.transform.position = Vector3.Lerp(biggerTasklist.transform.position, new Vector3(-0.35f, -4.2f, 0), Time.deltaTime * speed);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                showBigList = false;
                StartCoroutine(hideBiggerTasklistDelay());
                audioSource.Play();
            }
        }

        if (!showBigList)
        {
            biggerTasklist.transform.position = Vector3.Lerp(biggerTasklist.transform.position, bigOffScreen, Time.deltaTime * speed);
        }
    }

    void OnMouseEnter()
    {
        if (isOffScreen) return;
        targetPosition = originalPosition + Vector3.up * offset;  
    }

    void OnMouseExit()
    {
        if (isOffScreen) return;
        targetPosition = originalPosition;
    }

    void OnMouseDown()
    {
        isOffScreen = true;
        targetPosition = offScreen;
        StartCoroutine(biggerTasklistDelay());
        audioSource.Play();
    }

    IEnumerator biggerTasklistDelay()
    {
        yield return new WaitForSeconds(0.7f);
        showBigList = true;
        
    }

    IEnumerator hideBiggerTasklistDelay()
    {
        yield return new WaitForSeconds(0.7f);
        targetPosition = originalPosition;
        isOffScreen = false;
    }
}
