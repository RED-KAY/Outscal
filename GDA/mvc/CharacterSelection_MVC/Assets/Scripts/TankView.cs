using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController _TankController;
    float _Movement, _Rotation;
    float _MovementSpeed, _RotationSpeed;

    Rigidbody _Rigidbody;

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


}
