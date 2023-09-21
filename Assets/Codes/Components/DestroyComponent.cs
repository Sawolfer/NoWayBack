using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    public void Destory()
    {
        Destroy(_target);
    }
    
}
