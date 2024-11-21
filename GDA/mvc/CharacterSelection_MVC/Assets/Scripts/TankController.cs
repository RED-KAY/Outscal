using UnityEngine;

public class TankController
{
    TankView _tankView;
    TankModel _tankModel;

    public TankController(TankView tankView, TankModel tankModel)
    {
        _tankView = tankView;
        _tankModel = tankModel;

        _tankView.SetTankController(this);
        _tankModel.SetTankController(this);

        GameObject.Instantiate(_tankView.gameObject);
    }
}
