using System;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLoader : MonoBehaviour
{
    private const string CurrentPowerUpsKey = "PowerUpList";

    private readonly List<PowerUpTypes> _currentPowerUps = new() {PowerUpTypes.Nitros, PowerUpTypes.DistractCall, PowerUpTypes.LaserBeam};

    [ContextMenu("Save")]
    public void Save()
    {
        PlayerPrefs.SetString(CurrentPowerUpsKey, JsonUtility.ToJson(_currentPowerUps));
        PlayerPrefs.Save();
    }

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetString(CurrentPowerUpsKey, ""));
    }
}