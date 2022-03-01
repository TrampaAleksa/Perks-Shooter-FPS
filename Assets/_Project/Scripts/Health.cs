using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private long maxHealth = 100;
    [SerializeField]
    private long _currentHealth;

    public UnityEvent<long> healthChangedEvent;
    public UnityEvent healthZeroEvent;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public long CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > maxHealth)
            {
                _currentHealth = maxHealth;
                healthChangedEvent.Invoke(CurrentHealth);

                return;
            }

            if (value < 0)
            {
                _currentHealth = 0;
                healthChangedEvent.Invoke(CurrentHealth);
                healthZeroEvent?.Invoke();
                return;
            }

            _currentHealth = value;
            healthChangedEvent.Invoke(CurrentHealth);
        }
    }

    public void ReduceHealth(long amount)
    {
        CurrentHealth -= amount;
    }

    public void AddHealth(long amount)
    {
        CurrentHealth += amount;
    }

    public void RestoreToDefault()
    {
        CurrentHealth = maxHealth;
    }

    public bool IsMax()
    {
        return CurrentHealth == maxHealth;
    }

    private void OnValidate()
    {
        CurrentHealth = _currentHealth;
    }
}