using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private long maxHealth = 100;
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
                return;
            }

            if (value < 0)
            {
                _currentHealth = 0;
                healthZeroEvent?.Invoke();
                return;
            }

            _currentHealth = value;
        }
    }

    public void ReduceHealth(long amount)
    {
        CurrentHealth -= amount;
        healthChangedEvent?.Invoke(CurrentHealth);
    }

    public void AddHealth(long amount)
    {
        CurrentHealth += amount;
        healthChangedEvent.Invoke(CurrentHealth);
    }

    public void RestoreToDefault()
    {
        CurrentHealth = maxHealth;
    }
}