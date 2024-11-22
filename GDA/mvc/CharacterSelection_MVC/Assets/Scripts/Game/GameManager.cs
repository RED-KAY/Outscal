using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GenericMonoSingleton<GameManager>
{
    [SerializeField] GameObject[] _Screens;

    public void GameStart()
    {
        SceneManager.LoadScene(1);

        _Screens[0].SetActive(false);
        _Screens[1].SetActive(true);
    }

    public void Pause()
    {
        _Screens[2].SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _Screens[2].SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TankSelected()
    {
        _Screens[1].SetActive(false);
    }
}
