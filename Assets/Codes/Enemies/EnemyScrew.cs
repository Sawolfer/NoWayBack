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
    
    private List<Transform> _patrolPoint;
    private GameObject _player;
    private NavMeshAgent navMeshAgent;
    private int _currentPatrolPoint = 0;
    private bool _isPatrolling;

    protected override void Awake()
    {
        base.Awake();
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
            StartCoroutine(RecognizePlayer());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            StartCoroutine(ForgotPlayer());
        }
    }

    private IEnumerator RecognizePlayer(){
        StopCoroutine(Patrol());
        _isPatrolling = false;
        StartCoroutine(GoToPlayer());
        yield return null;
    }

    private IEnumerator ForgotPlayer(){
        StopCoroutine(GoToPlayer());
        StartCoroutine(Patrol());
        yield return null;
    }

    private IEnumerator Patrol() {
        _isPatrolling = true;
        _currentPatrolPoint = (_currentPatrolPoint + 1) % _patrolPoint.Count;
        navMeshAgent.destination = _patrolPoint[_currentPatrolPoint].position;
        float time = Vector2.Distance(_patrolPoint[_currentPatrolPoint].position, transform.position) / _speed;
        
        yield return new WaitForSeconds(time);
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
