using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarHP : BaseCarHP
{
    private void Start()
    {
        maxHealthPoint = 200f;
        currentHealthPoint = maxHealthPoint;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("NeutralCar"))
        {
            takeDamage(5f);
        }

        if (col.gameObject.CompareTag("PoliceCar"))
        {
            takeDamage(10f);
        }
        
        GameUIController.Instance.UpdateHealthBar(currentHealthPoint, maxHealthPoint);
    }
}
