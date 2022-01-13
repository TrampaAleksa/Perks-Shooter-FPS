using System;
using UnityEngine;

namespace _Project.Scripts.Weapons
{
    public class WeaponController : MonoBehaviour , IWeaponController
    {
        private IWeaponController _weaponController;
        public Weapon currentWeapon;
        private void Awake()
        {
            _weaponController = this;
        }

        private void Update()
        {
            _weaponController.HandleWeaponControls();
        }
        
        
        public void HandleWeaponControls()
        {
            if (!IsShotTriggered())
                return;
        
            Debug.Log("Weapon Shot Triggered");
            currentWeapon.Shoot();
        }
        private static bool IsShotTriggered()
        {
            return Input.GetKeyDown(KeyCode.Mouse0);
        }
    }
    
}