using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public enum TankType
{
    GreenTank,
    BlueTank,
    RedTank
}

[System.Serializable]
public struct Tank
{
    public float _MovementSpeed;
    public float _RotationSpeed;
    public TankType _Type;
    public Material _Color;
}

public class TankSpawner : MonoBehaviour
{
    public List<Tank> _TankList;

    [SerializeField] TankView _tank;

    TankController _tankController;

    public void SpawnTank(TankType tankToSpawn = TankType.GreenTank)
    {
        TankModel tankModel = new TankModel(_TankList[((int)tankToSpawn)]);
        _tankController = new TankController(_tank, tankModel);


    }
}
