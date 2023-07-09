using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    #region Singleton

    public static GameUIController Instance; 
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
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
    
    private void Start()
    {
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
}