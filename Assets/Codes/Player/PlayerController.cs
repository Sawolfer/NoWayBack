using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;


    [SerializeField] private float _speed;
    [SerializeField] private int  _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private CoolDownComponent _coolDown;
    [SerializeField] private CooldownFillerComponent _cooldownFiller;
    
    private void Awake()
    {
        _cooldownFiller.coolDown = _coolDown.coolDown;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_direction.x == 1 || _direction.x == -1)
        {
            transform.localScale = new Vector3(_direction.x, 1, 1); 
        }
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _direction.y * _speed); 
    }

    public void SetDirection(Vector2 newDirection)
    {
        _direction = newDirection;
    }

    public void Punch()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPosition.position, _attackRange);
        foreach (var man in enemies)
        {
            if (man.CompareTag("Enemy") && _coolDown.CDCheck())
            {
                var hp = man.GetComponent<HealthComponent>();
                hp.ApplyDamage(_damage);
                _coolDown.CDReset();
                _cooldownFiller.Reset();
            }
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_attackPosition.position, _attackRange);
    }
#endif
    
}
