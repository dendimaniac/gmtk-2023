using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneController : MonoBehaviour
{
    public void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Credits"));
    }
    
    public void Back()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}