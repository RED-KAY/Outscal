using UnityEngine;

public class TankSelection : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] TankSpawner _TankSpawner;
    public void TankSelected(int index)
    {
        //gameObject.SetActive(false);
        GameManager.Instance.TankSelected();
        _TankSpawner.SpawnTank((TankType)Mathf.Clamp(index, 0, 2));
    }
}
