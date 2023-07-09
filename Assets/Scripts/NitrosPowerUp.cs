using UnityEngine;

public class NitrosPowerUp : PowerUps
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float nitrosSpeed = 10f;

    public override PowerUpTypes Types => PowerUpTypes.Nitros;

    protected override void Trigger()
    {
        base.Trigger();
        playerMovement.UpdateSpeed(nitrosSpeed);
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        playerMovement.ResetSpeed();
    }
}