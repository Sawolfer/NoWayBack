using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpFillerComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent health;
    [SerializeField] private Image _healBar;


    private void FixedUpdate()
    {

        _healBar.fillAmount = health.HP / health.MaxHp;
    }
}
