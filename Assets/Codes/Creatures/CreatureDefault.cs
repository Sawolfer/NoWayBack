using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
using Random = System.Random;

public class CreatureDefault : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private GameObject _player;

    [SerializeField] private float _speed;
    [SerializeField] private AttackComponent _attack; 
    [SerializeField] private CoolDownComponent _waitTime;
    [SerializeField] private SpawnComponent _attackWarning;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
    }

    private void SetDirection(Vector2 direction)
    {
        _direction = direction;
        // transform.localScale = (direction.x > 0 && direction.x != 0) ? new Vector2(1, 1) : new Vector2(-1, 1);
    }
    
    private void FixedUpdate()
    {
        transform.localScale = (_player.transform.position.x > transform.position.x)
            ? new Vector2(1, 1) : new Vector2(-1, 1);
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _direction.y * _speed);
        var rnd = new Random();
        if (Vector2.Distance(_player.transform.position, transform.position) <= 1f)
        {
            SetDirection(Vector2.zero);
            
            StartCoroutine(TryToAttack());
            _waitTime.CDReset();
        }
        var _randomNumber = rnd.Next(0, 10);
        if (_waitTime.CDCheck())
        {
            switch (_randomNumber)
            { 
                case (<4): 
                    StartCoroutine(GoTohero()); 
                    break;
                
                case (>8):
                    Wait();
                    break;
                case (>4):
                    StartCoroutine(RandomMove());
                    break;
            }
        }
        
    }

    private void Wait()
    {
        _waitTime.CDReset();
        
    }
    
    [ContextMenu("GoToHero")]
    private IEnumerator GoTohero()
    {
        
        var hero = GameObject.FindWithTag("Player");
        var tmpDir = hero.transform.position - transform.position;
        tmpDir= tmpDir.normalized;
        SetDirection(tmpDir);
        yield return new WaitForSeconds(_waitTime.coolDown);
        SetDirection(Vector2.zero);
    }

    private IEnumerator RandomMove()
    {
        var rnd = new Random();
        float x = (rnd.Next(-10, 10)) / 10;
        float y = (rnd.Next(-10, 10)) / 10;
        Vector2 tmpDir = new Vector2(x, y);
        SetDirection(tmpDir);
        yield return new WaitForSeconds(_waitTime.coolDown);
        SetDirection(Vector2.zero);

    }

    private bool warning = false;
    public IEnumerator TryToAttack()
    {
        if (!warning)
        {
            _attackWarning.Spawn();
            warning = true;
        }
        
        yield return new WaitForSeconds(1f);
        warning = false;
        _attack.OnAttack();
    }
    
}
