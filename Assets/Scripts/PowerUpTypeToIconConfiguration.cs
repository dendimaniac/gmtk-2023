using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpTypeToIconConfiguration", menuName = "PowerUpTypeToIconConfiguration", order = 0)]
public class PowerUpTypeToIconConfiguration : ScriptableObject
{
    public List<PowerUpTypeToIcon> Icons;
}

[Serializable]
public class PowerUpTypeToIcon
{
    public PowerUpTypes Type;
    public Sprite Icon;
}