using UnityEngine;

public class SpikeTrapsPowerUp : PowerUps
{
    [SerializeField] private SpikeTrapManager spikeTrapManager;
    [SerializeField] private PlayerMovement playerMovement;

    public override PowerUpTypes Types => PowerUpTypes.SpikeTraps;

    private Vector3? _offSet;

    protected override void Trigger()
    {
        base.Trigger();
        var spikeTrap = spikeTrapManager.Get();
        _offSet ??= new Vector3(0, playerMovement.BoxColliderOffset + spikeTrap.VerticalBoxColliderOffset);
        spikeTrap.SetUp(spikeTrapManager);
        spikeTrap.transform.position = playerMovement.transform.position - _offSet.Value;
    }
}