using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    TankController _TankController;
    float _Movement, _Rotation;

    Rigidbody _Rigidbody;

    [SerializeField] MeshRenderer[] _Parts;
    [SerializeField] Slider _AimSlider;
    [SerializeField] float _MinLaunchForce, _MaxLaunchForce, _MaxChargeTime;
    float _CurrentLaunchForce;
    bool _Fired;
    string _FireButton = "Jump";
    float _ChargeSpeed;
    [SerializeField] Transform _FireTransform;
    [SerializeField] Rigidbody _Shell;

    bool _IsPaused;

    public void SetTankController(TankController tankController)
    {
        _TankController = tankController;
    }

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        SetCamera();

        _CurrentLaunchForce = _MinLaunchForce;
        _AimSlider.value = _MinLaunchForce;
        _ChargeSpeed = (_MaxLaunchForce - _MinLaunchForce) / _MaxChargeTime;
    }

    private void Update()
    {
        Movement();

        if (_Movement != 0) {
            _TankController.Move(_Movement);
        }

        if (_Rotation != 0) { 
            _TankController.Rotate(_Rotation);
        }

        CheckFireInput();

        if (Input.GetKeyUp(KeyCode.Escape) && !_IsPaused) { 
            GameManager.Instance.Pause();
            _IsPaused = true;
        }else if(Input.GetKeyUp(KeyCode.Escape) && _IsPaused)
        {
            GameManager.Instance.Resume();
            _IsPaused = false;
        }
    }

    void Movement()
    {
        _Movement = Input.GetAxis("Vertical");
        _Rotation = Input.GetAxis("Horizontal");
    }

    void CheckFireInput()
    {
        _AimSlider.value = _MinLaunchForce;

        if (_CurrentLaunchForce >= _MaxLaunchForce && !_Fired)
        {
            _CurrentLaunchForce = _MaxLaunchForce;
            Fire();
        }
        else if (Input.GetButtonDown(_FireButton))
        {
            _Fired = false;
            _CurrentLaunchForce = _MinLaunchForce;

            //m_ShootingAudio.clip = m_ChargingClip;
            //m_ShootingAudio.Play();
        }
        else if (Input.GetButton(_FireButton) && !_Fired)
        {
            _CurrentLaunchForce += _ChargeSpeed * Time.deltaTime;

            _AimSlider.value = _CurrentLaunchForce;
        }
        else if (Input.GetButtonUp(_FireButton) && !_Fired)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Set the fired flag so only Fire is only called once.
        _Fired = true;

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate(_Shell, _FireTransform.position, _FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.linearVelocity = _CurrentLaunchForce * _FireTransform.forward;

        //_ShootingAudio.clip = _FireClip;
        //_ShootingAudio.Play();

        _CurrentLaunchForce = _MinLaunchForce;
    }

    public Rigidbody GetRB()
    {
        return _Rigidbody;
    }

    public void ChangeColor(Material material)
    {
        for (int i = 0; i < _Parts.Length; i++)
        {
            _Parts[i].material = material;
        }
    }

    void SetCamera()
    {
        Camera mc = Camera.main;
        mc.transform.parent = transform;
        mc.transform.position = new Vector3(0f, 5f, -8f);
    }


}
