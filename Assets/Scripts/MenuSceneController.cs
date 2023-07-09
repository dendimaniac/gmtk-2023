using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    private void Start()
    {
        if (!SceneManager.GetSceneByName("Audio").isLoaded) SceneManager.LoadScene("Audio", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
    }

    public void StartGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void OpenOptions()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
        }

    public void Quit()
    {
        Application.Quit();
    }
}
