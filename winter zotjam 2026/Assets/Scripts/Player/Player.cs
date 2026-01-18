using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private Transform _cameraTransformCenter;
    [SerializeField] private UnityEngine.Vector3 _cameraTransformDown;

    public bool IsDown = false;
    public bool LookCenter = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsDown = false;
        LookCenter = true;
    }

    // Update is called once per frame
    void Update()
    {
        //camera movement
        if (!IsDown) //can look down or look left or right
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                IsDown = true;
                LookCenter = true;
                Debug.Log("is looking down");

                _camera.transform.position = _cameraTransformDown;


            }
            //strech goal
            if (Input.GetKeyDown(KeyCode.A))
            {
                
            }
        }

        if (IsDown) //can look back up; cant look left or right (strech goal)
        {
            if (Input.GetKeyDown(KeyCode.W))//looking up
            {
                IsDown = false;
                Debug.Log("is looking up");

                _camera.transform.position = _cameraTransformCenter.position;
            }
        }
        

    }
}
