using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliceCarHP : BaseCarHP
{
    [SerializeField] public Image _healthBarSprite;
    // Start is called before the first frame update
    private void Start()
    {
        maxHealthPoint = 25f;
        currentHealthPoint = maxHealthPoint;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        takeDamage(10f);
        _healthBarSprite.fillAmount = currentHealthPoint / maxHealthPoint;
    }

    private void OnDestroy()
    {
        GameUIController.Instance._policeCarStoppedCounter++;
        GameUIController.Instance.UpdatePoliceCarStopped(GameUIController.Instance._policeCarStoppedCounter);
    }
}
