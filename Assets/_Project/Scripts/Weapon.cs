using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float baseWeaponDamage = 1f;

    // Update is called once per frame
    void Update()
    {
        HandleWeaponInput();
    }

    private void HandleWeaponInput()
    {
        if (!IsShotTriggered())
            return;
        
        Debug.Log("Weapon Fired");
        Shoot();
    }

    private static bool IsShotTriggered()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    public abstract void Shoot();
    public float BaseWeaponDamage
    {
        get => baseWeaponDamage;
        set => baseWeaponDamage = value;
    }

}