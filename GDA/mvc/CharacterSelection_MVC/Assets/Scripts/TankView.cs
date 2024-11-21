using UnityEngine;
using UnityEngine.Rendering;

public class TankView : MonoBehaviour
{
    TankController _TankController;
    float _Movement, _Rotation;
    float _MovementSpeed, _RotationSpeed;

    Rigidbody _Rigidbody;

    [SerializeField]MeshRenderer[] _Parts;

    public void SetTankController(TankController tankController)
    {
        _TankController = tankController;

        _MovementSpeed = _TankController.GetModel()._MovementSpeed;
        _RotationSpeed = _TankController.GetModel()._RotationSpeed;
    }

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        Camera mc = Camera.main;
        mc.transform.parent = transform;
        mc.transform.position = new Vector3(0f, 3f, -4f);
    }

    private void Update()
    {
        Movement();

        if (_Movement != 0) {
            _TankController.Move(_Movement, _MovementSpeed);
        }

        if (_Rotation != 0) { 
            _TankController.Rotate(_Rotation, _RotationSpeed);
        }
    }

    void Movement()
    {
        _Movement = Input.GetAxis("Vertical");
        _Rotation = Input.GetAxis("Horizontal");
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
}
