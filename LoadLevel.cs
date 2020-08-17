using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void PressPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LevelLoad(int index)
    {
        SceneManager.LoadScene(index + 1);
    }
}
