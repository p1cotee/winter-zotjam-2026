using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private Transform _cameraTransformCenter;
    [SerializeField] private UnityEngine.Vector3 _cameraTransformDown;
    [SerializeField] private float _cameraMoveSpeed = 5f;

    public bool IsDown = false;
    public bool LookCenter = true;
    public bool MoveDown = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsDown = false;
        LookCenter = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera movement
        if (!IsDown) //can look down 
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                IsDown = true;
                LookCenter = false;
                Debug.Log("is looking down");

                MoveDown = true;

                Debug.Log(_camera.transform.position);
            }
            /*
            //strech goal, left and right look
            if (Input.GetKeyDown(KeyCode.A))
            {

            }
            */

            //blink
            if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
            {
                Blink();
            }
        }

        if (IsDown) //can look back up; cant look left or right (strech goal)
        {
            if (Input.GetKeyDown(KeyCode.W))//looking up
            {
                IsDown = false;
                LookCenter = true;
                Debug.Log("is looking up");

                //_camera.transform.position = _cameraTransformCenter.position;

                MoveDown = false;
            }
        }
    }

    //chekcing for camera movement (i need to put it here cuz lerp is frame dependent)
    void LateUpdate()
    {
        if (MoveDown == true)
        {
            if (UnityEngine.Vector3.Distance(_camera.transform.position, _cameraTransformDown) < 0.1f)
            {
                _camera.transform.position = _cameraTransformDown;

                return;
            }
            else
            {
                CameraMovement(_camera.transform.position, _cameraTransformDown);
            } 
        }

        if (MoveDown == false)
        {
            if (UnityEngine.Vector3.Distance(_camera.transform.position, _cameraTransformCenter.position) < 0.1f)
            {
                _camera.transform.position = _cameraTransformCenter.position;

                return;
            }
            else
            {
                CameraMovement(_camera.transform.position, _cameraTransformCenter.position);
            }
        }
    }

    //camera movement lerp function 
    private void CameraMovement(UnityEngine.Vector3 original, UnityEngine.Vector3 target)
    {
        _camera.transform.position = UnityEngine.Vector3.Lerp(
            original, 
            target, 
            _cameraMoveSpeed * Time.deltaTime);
    }

    public void Blink() //make it an event
    {
        //reset the timer
        //clear the blur filter
        //plus 1 to the blink counter
        //play blink sfx
        //play blink animation
        Debug.Log("blinked");
    }
}
