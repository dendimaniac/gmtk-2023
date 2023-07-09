using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobberCarHP : BaseCarHP
{
    [SerializeField] public Image _healthBarSprite;
    private void Start()
    {
        maxHealthPoint = 100f;
        currentHealthPoint = maxHealthPoint;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        takeDamage(5f);
        _healthBarSprite.fillAmount = currentHealthPoint / maxHealthPoint;
    }

    private void OnDestroy()
    {
        GameUIController.Instance.GameOver();
    }
}
