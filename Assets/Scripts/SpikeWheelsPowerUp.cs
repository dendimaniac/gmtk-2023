using UnityEngine;

public class SpikeWheelsPowerUp : PowerUps
{
    [SerializeField] private GameObject spikeWheelContainer;
    
    public override PowerUpTypes Types => PowerUpTypes.SpikeWheels;

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