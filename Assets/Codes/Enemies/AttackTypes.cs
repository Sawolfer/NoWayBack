using Unity.VisualScripting;
using UnityEngine;

public abstract class AttackTypes
{
    public int _damage {get; set;}
    protected GameObject GetPlayer() {
        return GameObject.FindWithTag("Player"); 
    }

    public abstract void PerFormAttack();
}