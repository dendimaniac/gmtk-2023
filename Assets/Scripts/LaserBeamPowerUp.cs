using UnityEngine;

public class LaserBeamPowerUp : PowerUps
{
    [SerializeField] private GameObject laserBeam;
    
    public override PowerUpTypes Types => PowerUpTypes.LaserBeam;

    protected override void Trigger()
    {
        base.Trigger();
        laserBeam.SetActive(true);
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        laserBeam.SetActive(false);
    }
}