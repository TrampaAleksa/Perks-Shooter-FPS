using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public float direction = 1f;
    
    [SerializeField]
    private float liftSpeed = 1f;
    [SerializeField]
    private LiftCollider lowerCollider, upperCollider;

    
    private Transform _transform;
    private bool _isLiftActive;
    void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (!_isLiftActive)
            return;
            
        _transform.Translate(Vector3.up * (direction * liftSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            StartLift();
    }

    public void StartLift() => _isLiftActive = true;
    public void StopLift() => _isLiftActive = false;
}