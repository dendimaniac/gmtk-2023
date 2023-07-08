using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCarHP : MonoBehaviour
{
    protected float healthPoint;

    public void takeDamage(float dmg)
    {
        healthPoint -= dmg;
        if (healthPoint < 0)
        {
            Destroy(gameObject);
        }
    }
}
