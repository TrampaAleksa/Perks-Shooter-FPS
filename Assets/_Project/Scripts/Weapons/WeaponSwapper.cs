using System;
using UnityEngine;

namespace _Project.Scripts.Weapons
{
    public class WeaponSwapper : MonoBehaviour
    {
        [SerializeField]
        private Weapon pistol;
        [SerializeField]
        private Weapon rifle;
        [SerializeField]
        private WeaponController controller; //todo - consider renaming

        private void Update()
        {
            HandleSwapInput();
        }

        private void HandleSwapInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                controller.CurrentWeapon = pistol;
            if (Input.GetKeyDown(KeyCode.Alpha2))
                controller.CurrentWeapon = rifle;
        }
    }
}