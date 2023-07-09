using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarHP : BaseCarHP
{
    // Start is called before the first frame update
    private void Start()
    {
        maxHealthPoint = 50f;
        currentHealthPoint = maxHealthPoint;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        takeDamage(10f);
    }
}
