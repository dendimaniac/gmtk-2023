using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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
    [SerializeField] public GameObject[] powerUps;

    [SerializeField] public TextMeshProUGUI timerText;
    private float _timer;
    [SerializeField] public TextMeshProUGUI policeStoppedText;
    public int _policeCarStoppedCounter;
    
    public GameOverCanvas gameOverCanvas;
    
    public float powerUpTimer;
    
    
    private void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.gameObject.SetActive(false);
        
        _healthBarSprite.fillAmount = 1;
        _timer = 0f;
        _policeCarStoppedCounter = 0;
        UpdatePoliceCarStopped(_policeCarStoppedCounter);
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

    public void TogglePowerUp(int powerUpNumber)
    {
        StartCoroutine(ITogglePowerUp(powerUps[powerUpNumber], powerUpTimer));
    }

    IEnumerator ITogglePowerUp(GameObject powerUp, float seconds)
    {
        powerUp.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        powerUp.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.timeText.text = $"Time sabotaged: {timerText.text}";
        gameOverCanvas.crashCountText.text = $"Police car crashed: {_policeCarStoppedCounter.ToString()}";
        gameOverCanvas.gameObject.SetActive(true);
    }
}