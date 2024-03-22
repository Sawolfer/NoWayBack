using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScrew : CreatureDefault
{
    [SerializeField] private EnemyClass _enemyClass;
    [SerializeField] private Collider2D _visionRange;
    [SerializeField] protected float _coolDown;
    
    [SerializeField] private List<Transform> _patrolPoint;
    private GameObject _player;
    private NavMeshAgent navMeshAgent;
    private int _currentPatrolPoint = 0;
    private bool _isPatrolling;

    protected override void Awake()
    {
        base.Awake();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        GameObject[] points = GameObject.FindGameObjectsWithTag("PatrolPoint");
        foreach (var item in points){
            _patrolPoint.Add(item.GetComponent<Transform>());
        }
        _player = GameObject.FindWithTag("Player");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void Start()
    {
        StartCoroutine(Patrol());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            StartCoroutine(RecognisePlayer());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            StartCoroutine(ForgotPlayer());
        }
    }

    private IEnumerator RecognisePlayer(){
        StopCoroutine(Patrol());
        _isPatrolling = false;
        StartCoroutine(Wait("GoToPlayer"));
        yield return null;
    }

    private IEnumerator ForgotPlayer(){
        StartCoroutine(Patrol());
        yield return null;
    }

    private IEnumerator Patrol() {
        _isPatrolling = true;
        _currentPatrolPoint = (_currentPatrolPoint + 1) % _patrolPoint.Count;
        navMeshAgent.destination = _patrolPoint[_currentPatrolPoint].position;
        yield return new WaitForSeconds(1);
        StartCoroutine(Patrol());
    }

    private IEnumerator GoToPlayer(){
        navMeshAgent.destination = _player.transform.position;
        yield return null;
    }

    private IEnumerator Wait(string coroutine){
        SetDirection(Vector2.zero);
        yield return new WaitForSeconds(_coolDown);
        StartCoroutine(coroutine);
    }

}
