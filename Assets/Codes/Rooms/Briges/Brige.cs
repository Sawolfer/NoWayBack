using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brige : MonoBehaviour
{

    [SerializeField] private Transform _positionToSpawn;
    [SerializeField] private GameObject Room;

    public void SpawnRoom()
    {
        Instantiate(Room, _positionToSpawn.position, Quaternion.identity);
    }
    
    public void DesroyOtherBriges()
    {
        gameObject.tag = "UnbreakableBrige";
        var other = GameObject.FindGameObjectsWithTag("Brige");
        foreach (var brige in other)
        {
            Destroy(brige);
        }
    }
    public void DestroyRooms()
    {
        var _otherRooms = GameObject.FindGameObjectsWithTag("PreviousRoom");

        foreach (var _room in _otherRooms)
        {
            Destroy(_room);
        }
    }

    public void DestroyBrige()
    {
        Destroy(this.gameObject);
    }
}
