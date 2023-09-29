using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.PlayerLoop;


[Serializable]
public class CoolDownComponent 
{
    public bool coolDownIsReady = true;
    public float coolDown;
    private float nextTime;

    private void FixedUpdate()
    {
        CDCheck();
    }
    public void CDReset()
    {
        coolDownIsReady = false;
        nextTime = Time.time + coolDown;
    }

    public bool CDCheck()
    {
        if (Time.time >= nextTime)
        {
            coolDownIsReady = true;
            return true;
        }
        return false;
    }
}
