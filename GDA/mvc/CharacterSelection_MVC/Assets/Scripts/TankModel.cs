using UnityEngine;

public class TankModel
{
    TankController _tankController;

    public TankModel()
    {

    }

    public void SetTankController( TankController tankController)
    {
        _tankController = tankController;
    }
}
