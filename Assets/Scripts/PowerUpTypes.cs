using System;

public enum PowerUpTypes
{
    SpikeTraps,
    SpikeWheels,
    Nitros,
    DistractCall,
    LaserBeam
}

public static class PowerUpsTypesHelper
{
    public static Type GetHandler(PowerUpTypes powerUpTypes)
    {
        switch (powerUpTypes)
        {
            default:
            case PowerUpTypes.SpikeTraps:
                return typeof(SpikeTrapsPowerUp);
            case PowerUpTypes.SpikeWheels:
                return typeof(SpikeWheelsPowerUp);
            case PowerUpTypes.Nitros:
                return typeof(NitrosPowerUp);
            case PowerUpTypes.LaserBeam:
                return typeof(LaserBeamPowerUp);
        }
    }
}