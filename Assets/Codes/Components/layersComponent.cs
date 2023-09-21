using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class layersComponent : MonoBehaviour
{
    private GameObject player;
    private TilemapRenderer tilemap;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        tilemap = GetComponent<TilemapRenderer>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= player.transform.position.y)
        {
            
        }
    }
}
