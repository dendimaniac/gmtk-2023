using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCarHP : MonoBehaviour
{
    protected float maxHealthPoint;
    protected float currentHealthPoint;
    public GameObject explosionPrefab;

    public void takeDamage(float dmg)
    {
        currentHealthPoint -= dmg;
        SoundManager.Instance.PlaySound("Crash_metal1");
        if (currentHealthPoint < 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
