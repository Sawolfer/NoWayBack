using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;
    [SerializeField] private CoolDownComponent _livetime;
    // Start is called before the first frame update
    void Start()
    {
        _livetime.CDReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (_livetime.CDCheck())
        {
            _action?.Invoke();
        }
    }
}
