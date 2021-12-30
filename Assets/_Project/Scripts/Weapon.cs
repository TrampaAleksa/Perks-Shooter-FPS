using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletHole;
    public Animator anim;
    [SerializeField]
    private long weaponDamage = 10;

    // Update is called once per frame
    void Update()
    {
        HandleWeaponInput();
    }

    private void HandleWeaponInput()
    {
        if (IsShotTriggered())
        {
            Debug.Log("Weapon Fired");
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        anim.SetTrigger("Shoot");

        var rayHitTarget = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit,
            Mathf.Infinity);

        DrawShotRay(rayHitTarget, hit);
        if (rayHitTarget)
            HandleTargetHit(hit);
    }

    private void DrawShotRay(bool rayHitTarget, RaycastHit hit)
    {
        if (rayHitTarget)
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
        else
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
    }

    private void HandleTargetHit(RaycastHit hit)
    {
        Enemy enemy = hit.collider.GetComponent<Enemy>();
        if (enemy == null) return;
        
        enemy.ReduceHealth(weaponDamage);
        Debug.Log($"Hit an Enemy for: {weaponDamage} . Enemy has :{enemy.Health} remaining health");

        // CreateBulletHole(hit);
    }

    private void CreateBulletHole(RaycastHit hit)
    {
        MeshCollider coll = (MeshCollider) hit.collider;
        Instantiate(bulletHole, hit.point + (hit.transform.right * 0.003f),
            Quaternion.Euler(hit.transform.localRotation.eulerAngles + new Vector3(0, 90, 0)));
    }

    private static bool IsShotTriggered()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }
}