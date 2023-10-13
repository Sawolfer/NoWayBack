using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownFillerComponent : MonoBehaviour
{
    public float coolDown;
    [SerializeField] private Text text;
    private float nextTime;
    private void Update()
    {
        if (nextTime >= Time.time)
        {
            decimal number = (decimal)(nextTime - Time.time);
            number = Math.Round(number, 2, MidpointRounding.AwayFromZero);
            text.text = (number).ToString();
        }
        else
        {
            text.text = "shiiiiish";
        }
    }

    public void Reset()
    {
        nextTime = Time.time + coolDown;
    }
}
