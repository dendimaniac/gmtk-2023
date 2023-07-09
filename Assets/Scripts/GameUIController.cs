using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] public GameObject[] powerUps;
    public float powerUpTimer;
    private void Start()
    {
        _healthBarSprite.fillAmount = 1;
        //test for powerup2
        TogglePowerUp(2);
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
}