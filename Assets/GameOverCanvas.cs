using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI crashCountText;

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
