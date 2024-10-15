using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 _offset;
    [SerializeField, Range(0f,1f)] private float damp = 0.1f;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        //throw new NotImplementedException();
        Vector3 target_position = target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, target_position, damp);
    }
    
}
