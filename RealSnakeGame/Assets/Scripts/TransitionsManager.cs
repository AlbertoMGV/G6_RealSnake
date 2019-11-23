using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsManager : MonoBehaviour {
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
