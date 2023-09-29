using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private int  _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private CoolDownComponent _coolDown;


    // ReSharper disable Unity.PerformanceAnalysis
    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPosition.position, _attackRange);
        foreach (var man in enemies)
        {
            if (man.CompareTag("Player") && _coolDown.CDCheck())
            {
                var hp = man.GetComponent<HealthComponent>();
                hp.ApplyDamage(_damage);
                _coolDown.CDReset();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnAttack();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_attackPosition.position, _attackRange);
    }
#endif
}
