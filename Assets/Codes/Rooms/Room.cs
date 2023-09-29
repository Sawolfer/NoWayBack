using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject doors;

    
    private void FixedUpdate()
    {
        GameObject[] Barrels = GameObject.FindGameObjectsWithTag("Enemy");
        if (Barrels.Length == 0)
        {
            doors.SetActive(false);
        }
        else
        {
            doors.SetActive(true);
        }
    }
    
    [ContextMenu("Enterance")]
    public void Enterance()
    {
        
        Instantiate(barrel, gameObject.transform.position, quaternion.identity);
    }
}
