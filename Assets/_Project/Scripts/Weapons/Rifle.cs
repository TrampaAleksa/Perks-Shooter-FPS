using UnityEngine;

namespace _Project.Scripts.Weapons
{
    public class Rifle : Weapon
    {
        public GameObject bulletHole;
        [SerializeField] private long rifleDamage = 10;
        public Animator anim;
        private Transform _playerCamera;

        private void Awake()
        {
            _playerCamera = Camera.main.transform;
        }

        public override void Shoot()
        {
            RaycastHit hit;
            anim.SetTrigger("Shoot");

            var rayHitTarget = Physics.Raycast(_playerCamera.position, _playerCamera.forward, out hit,
                Mathf.Infinity);

            DrawShotRay(rayHitTarget, hit);
            if (rayHitTarget)
                HandleTargetHit(hit);
        }

        private void DrawShotRay(bool rayHitTarget, RaycastHit hit)
        {
            if (rayHitTarget)
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance,
                    Color.yellow);
            else
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
        }

        private void HandleTargetHit(RaycastHit hit)
        {
            Health health = hit.collider.GetComponent<Health>();
            if (health == null) return;

            health.ReduceHealth(rifleDamage);
            Debug.Log($"Hit a Target for: {rifleDamage}");

            // CreateBulletHole(hit);
        }

        private void CreateBulletHole(RaycastHit hit)
        {
            MeshCollider coll = (MeshCollider) hit.collider;
            Instantiate(bulletHole, hit.point + (hit.transform.right * 0.003f),
                Quaternion.Euler(hit.transform.localRotation.eulerAngles + new Vector3(0, 90, 0)));
        }
    }


    internal class RiflePrimaryShot : IShoot
    {
        public void Shoot()
        {
            Debug.Log("Shot fired!");
        }
    }
}