using System;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWheelsPowerUp : PowerUps
{
    [SerializeField] private GameObject spikeWheelContainer;
    [SerializeField] private List<SpikeWheel> spikeWheels;
    [SerializeField] private float damage;
    
    public override PowerUpTypes Types => PowerUpTypes.SpikeWheels;

    private void Awake()
    {
        foreach (var spikeWheel in spikeWheels)
        {
            spikeWheel.SetUp(damage);
        }
    }

    protected override void Trigger()
    {
        base.Trigger();
        spikeWheelContainer.SetActive(true);
    }
    
    protected override void Deactivate()
    {
        base.Deactivate();
        spikeWheelContainer.SetActive(false);
    }
}