using UnityEngine;
using UnityEngine.UIElements;

public class TankController
{
    TankView _TankView;
    TankModel _TankModel;
    Rigidbody _Rigidbody;

    public TankController(TankView tankView, TankModel tankModel)
    {
        _TankView = GameObject.Instantiate<TankView>(tankView);
        _TankModel = tankModel;

        _TankView.SetTankController(this);
        _TankModel.SetTankController(this);
        _Rigidbody = _TankView.GetRB();

        _TankView.ChangeColor(_TankModel._Material);
    }

    public void Move(float m)
    {
        _Rigidbody.linearVelocity = _TankView.transform.forward * m * _TankModel._MovementSpeed;
    }

    public void Rotate(float r)
    {
        Vector3 vector = new Vector3(0f, r * _TankModel._RotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        _Rigidbody.MoveRotation(_Rigidbody.rotation * deltaRotation);
    }

    public TankModel GetModel()
    {
        return _TankModel;
    }
}
