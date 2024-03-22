using System.Collections;
using UnityEngine;
using Random = System.Random;

public class CreatureDefault : MonoBehaviour
{
    protected Vector2 _direction;
    protected Rigidbody2D _rigidbody;


    [SerializeField] protected float _speed;
    [SerializeField] protected AttackComponent _attack; 
    [SerializeField] protected CoolDownComponent _waitTime;
    [SerializeField] protected SpawnComponent _attackWarning;
    
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    protected virtual void SetDirection(Vector2 direction)
    {
        _direction = direction;
        
    }
    
    protected virtual void FixedUpdate()
    {

        
    }

    // private void Wait()
    // {
    //     _waitTime.CDReset();
        
    // }
    
    // [ContextMenu("GoToHero")]
    // private IEnumerator GoTohero()
    // {
        
    //     var tmpDir = _player.transform.position - transform.position;
    //     tmpDir= tmpDir.normalized;
    //     SetDirection(tmpDir);
    //     yield return new WaitForSeconds(_waitTime.coolDown);
    //     SetDirection(Vector2.zero);
    // }

    // private IEnumerator RandomMove()
    // {
    //     var rnd = new Random();
    //     float x = (rnd.Next(-10, 10)) / 10;
    //     float y = (rnd.Next(-10, 10)) / 10;
    //     Vector2 tmpDir = new Vector2(x, y);
    //     SetDirection(tmpDir);
    //     yield return new WaitForSeconds(_waitTime.coolDown);
    //     SetDirection(Vector2.zero);

    // }

    // private bool warning = false;
    // public IEnumerator TryToAttack()
    // {
    //     if (!warning)
    //     {
    //         _attackWarning.Spawn();
    //         warning = true;
    //     }
        
    //     yield return new WaitForSeconds(1f);
    //     warning = false;
    //     _attack.OnAttack();
    // }
    
}
