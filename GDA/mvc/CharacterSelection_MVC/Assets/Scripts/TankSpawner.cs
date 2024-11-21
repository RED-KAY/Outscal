using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] TankView _tank;

    TankController _tankController;

    void Start()
    {
        SpawnTank();
    }

    void SpawnTank()
    {
        TankModel tankModel = new TankModel(30, 100);
        _tankController = new TankController(_tank, tankModel);


    }
}
