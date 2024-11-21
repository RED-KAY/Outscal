using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] TankSpawner _TankSpawner;
    public void TankSelected(int index)
    {
        _TankSpawner._TankToSpawn = (TankType) index;
        gameObject.SetActive(false);

        _TankSpawner.SpawnTank();
    }
}
