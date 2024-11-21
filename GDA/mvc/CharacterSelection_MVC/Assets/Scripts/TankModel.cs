using UnityEngine;

public class TankModel
{
    TankController _tankController;

    public float _MovementSpeed, _RotationSpeed;

    public TankModel(float m, float r)
    {
        _MovementSpeed = m;
        _RotationSpeed = r;
    }

    public void SetTankController( TankController tankController)
    {
        _tankController = tankController;
    }
}
