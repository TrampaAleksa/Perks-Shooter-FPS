using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private long maxHealth = 100;
    private long _health;

    public long Health
    {
        get => _health;
        set
        {
            if (value > maxHealth)
            {
                _health = maxHealth;
                return;
            }
            if (value < 0)
            {
                _health = 0;
                return;
            }
            
            _health = value;
        }
    }
}
