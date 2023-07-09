using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCarHP : MonoBehaviour
{
    protected float maxHealthPoint;
    protected float currentHealthPoint;

    public void takeDamage(float dmg)
    {
        currentHealthPoint -= dmg;
        SoundManager.Instance.PlaySound("Crash_metal1");
        if (currentHealthPoint < 0)
        {
            Destroy(gameObject);
        }
    }
}
