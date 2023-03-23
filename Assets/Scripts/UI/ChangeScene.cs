using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {

        Time.timeScale = 1;

        SceneManager.LoadScene(sceneName);
    }
}
