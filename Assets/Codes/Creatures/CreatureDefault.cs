using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class CreatureDefault : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;


    [SerializeField] private float _speed;
    [SerializeField] private int  _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private CoolDownComponent _coolDown;
    [SerializeField] private CoolDownComponent _waitTime;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    
    
    
    
}
