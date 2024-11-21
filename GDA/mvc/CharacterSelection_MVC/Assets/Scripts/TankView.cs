using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController _tankController;

    public void SetTankController(TankController tankController)
    {
        _tankController = tankController;
    }
}
