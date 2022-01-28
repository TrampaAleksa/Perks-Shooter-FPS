using System;
using UnityEngine;

namespace _Project.Scripts.Weapons
{
    public class WeaponController : MonoBehaviour , IWeaponController
    {
        private IWeaponController _weaponController;
        public Weapon currentWeapon;

        private TimedAction _timedAction;
        private bool _canFireWeapon = true;

        private void Awake()
        {
            _weaponController = this;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false); // todo - consider wrapping the timed action
        }
        private void Update()
        {
            _weaponController.HandleWeaponControls();
        }


        public void HandleWeaponControls() //todo - extract interface for controls with rate of fire and without rate of fire
        {
            if (IsShotTriggerPressed()){}

            if (IsShotTriggerHeld())
            {
                if (_canFireWeapon)
                {
                    Debug.Log("Weapon Shot Triggered");
                    CurrentWeapon.Shoot();
                    _canFireWeapon = false;
                    StartWeaponCooldown();
                }
            }

            if (IsShotTriggerReleased()){}

        }

        public Weapon CurrentWeapon
        {
            get => currentWeapon;
            set
            {
                currentWeapon.gameObject.SetActive(false);
                currentWeapon = value;
                currentWeapon.gameObject.SetActive(true);
            }
        }

        private static bool IsShotTriggerPressed()
            => Input.GetKeyDown(KeyCode.Mouse0);
        private static bool IsShotTriggerHeld()
            => Input.GetKey(KeyCode.Mouse0);
        private static bool IsShotTriggerReleased()
            => Input.GetKeyUp(KeyCode.Mouse0);
        private void StartWeaponCooldown()
            => _timedAction.StartTimedAction(() => _canFireWeapon = true, CurrentWeapon.rateOfFire);
    }

}