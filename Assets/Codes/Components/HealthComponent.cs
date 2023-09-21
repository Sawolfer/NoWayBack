using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public float HP;
    public float MaxHp;
    [SerializeField] private UnityEvent _onDie;

    private void Awake()
    {
        MaxHp = HP;
    }

    public void ApplyDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            OnDie();
        }
    }

    public void Heal(int heal)
    {
        HP += heal;
    }

    private void OnDie()
    {
        var _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
        _onDie?.Invoke();
    } 
}
