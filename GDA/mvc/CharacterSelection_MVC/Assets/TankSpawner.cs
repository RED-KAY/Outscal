using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] GameObject _tank;

    void Start()
    {
        Instantiate(_tank, transform.position, Quaternion.identity);
    }

}
