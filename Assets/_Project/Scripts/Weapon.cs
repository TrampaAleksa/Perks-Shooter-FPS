using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float _baseWeaponDamage = 1f;
    public float rateOfFire = 1f ; //todo - extract weapon Data and Weapon Methods as Separate Components
    public abstract void Shoot();
    public float BaseWeaponDamage
    {
        get => _baseWeaponDamage;
        set => _baseWeaponDamage = value;
    }

}