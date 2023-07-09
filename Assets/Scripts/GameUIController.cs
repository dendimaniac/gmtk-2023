using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    #region Singleton

    public static GameUIController Instance; 
    private void Awake()
    {
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    #endregion

    [SerializeField] public Image _healthBarSprite;
    [SerializeField] public TextMeshProUGUI timerText;
    private float _timer;
    [SerializeField] public TextMeshProUGUI policeStoppedText;
    public int _policeCarStoppedCounter;
    
    public GameOverCanvas gameOverCanvas;

    private void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.gameObject.SetActive(false);
        
        _healthBarSprite.fillAmount = 1;
        _timer = 0f;
        _policeCarStoppedCounter = 0;
        UpdatePoliceCarStopped(_policeCarStoppedCounter);
        
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(_timer);
        timerText.text = time.ToString(@"mm\:ss");
    }

    public void UpdatePoliceCarStopped(int count)
    {
        policeStoppedText.text = $"Police stopped: {count}";
    }
    
    public void UpdateHealthBar(float currentHp, float maxHp)
    {
        _healthBarSprite.fillAmount = currentHp / maxHp;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.timeText.text = $"Time sabotaged: {timerText.text}";
        gameOverCanvas.crashCountText.text = $"Police car crashed: {_policeCarStoppedCounter.ToString()}";
        gameOverCanvas.gameObject.SetActive(true);
    }
}