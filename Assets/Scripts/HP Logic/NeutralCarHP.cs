using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralCarHP : BaseCarHP
{
    // Start is called before the first frame update
    private void Start()
    {
        maxHealthPoint = 1f;
        currentHealthPoint = maxHealthPoint;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        takeDamage(5f);
    }
}
