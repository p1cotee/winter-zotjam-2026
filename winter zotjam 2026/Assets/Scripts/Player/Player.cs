using System.Collections;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private Transform _cameraTransformCenter;
    [SerializeField] private UnityEngine.Vector3 _cameraTransformDown;
    [SerializeField] private float _cameraMoveSpeed = 5f;
    [SerializeField] private float _blinkCoolDown = 2f;
    [SerializeField] private AudioSource _headTurnSfx; //head turn sfx
    [SerializeField] private AudioSource _blinkSfx; //blink sfx
    [SerializeField] private AudioSource _caughtSfx; //caught sfx
    [SerializeField] private CrushManager crushManager;


    public bool IsDown = false;
    public bool LookCenter = true;
    public bool MoveDown = false;
    public bool IsBlinking = false;
    private bool _blinkIsCooling = false;
    

    public static Player Instance {get; private set;} //make player as a singleton
    public delegate void EmptyDelegate();//this is the delegate
    public event EmptyDelegate OnBlink; //this is the blink event

    public int blinkCount = 0;
    public int PlayerHP = 2; //total hp
    
    void Awake()//null check for singleto
    {
        //making a singleton
        if (Instance != null && Instance != this)
        {
            // this is not the first singletone so it should be destoryed
            Destroy(this);
            return;
        }

        // make a singleton
        Instance = this;
        Debug.Log("Player singleton initialized");
    }


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

    void Update()//okay unity i actually hate you for this; blink when press space
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsBlinking && !_blinkIsCooling)
        {
            IsBlinking = true;
            Blink();
            StartCoroutine(BlinkCooldown());

        }
    }

    IEnumerator BlinkCooldown()
    {
        _blinkIsCooling = true;
        yield return new WaitForSeconds(_blinkCoolDown); //1 second cooldown
        _blinkIsCooling = false;
        Debug.Log("blink cooldown ended");
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
                PlayHeadTurnSfx();
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
                PlayHeadTurnSfx();
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
        //play blink animation?

        blinkCount++;
        OnBlink?.Invoke(); //fire the blink event, if there are any subscribers
        _blinkSfx.Play();
        IsBlinking = false;
        Debug.Log("blinked, total blink count: " + blinkCount);
    }

    private void PlayHeadTurnSfx()
    {
        _headTurnSfx.Play();
    }

    public void GotCaught(bool isLookingAtPlayer) //got caught looking
    {
        //hp -1
        //play caught sfx
        if (isLookingAtPlayer && LookCenter) //crush is looking back, and player didnt look away
        {
            PlayerHP -= 1;
            _caughtSfx.Play();
            Debug.Log("Player got caught! Remaining HP: " + PlayerHP);
            HealthUI.Instance.UpdateHealth(PlayerHP);
        }

        else
        {
            return;
        }
        

    }
}
