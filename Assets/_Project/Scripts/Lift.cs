using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Lift : MonoBehaviour
{
    public float direction = 1f;
    public float delayBeforeLowering = 1f;

    [SerializeField]
    private float liftSpeed = 1f;
    
    private Transform _transform;
    private bool _isLiftActive;

    private CharacterCollider _characterOnLift;

    void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (!_isLiftActive) return;
            
        _characterOnLift.controller.Move(Vector3.up * (direction * liftSpeed * Time.deltaTime));
        _transform.Translate(Vector3.up * (direction * liftSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _characterOnLift = other.GetComponent<CharacterCollider>(); //TODO - create custom collider with direct reference to controller and auto setup
            StartLift();
        }
    }

    [ContextMenu("StartLift")]
    public void StartLift() => _isLiftActive = true;
    public void StopLift() => _isLiftActive = false;
}