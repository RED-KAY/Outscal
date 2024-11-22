using UnityEngine;

public class TankModel
{
    TankController _tankController;

    public float _MovementSpeed, _RotationSpeed;

    public TankType _Type;

    public Material _Material;

    

    public TankModel(Tank t)
    {
        _MovementSpeed = t._MovementSpeed;
        _RotationSpeed = t._RotationSpeed;
        _Type = t._Type;
        _Material = t._Color;
    }

    public void SetTankController( TankController tankController)
    {
        _tankController = tankController;
    }
}
