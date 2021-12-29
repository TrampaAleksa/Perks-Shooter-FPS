using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    RaycastHit hit;
    public GameObject bulletHole;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        HandleWeaponInput();
    }

    private void HandleWeaponInput()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
        
        Debug.Log("Weapon Fired");
            
        // Does the ray intersect any objects excluding the player layer
        var rayHitTarget = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity);
        if (rayHitTarget)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            Debug.Log(hit.transform.name);
            // MeshCollider coll =(MeshCollider) hit.collider;
            // Instantiate(bulletHole, hit.point + (hit.transform.right * 0.003f), Quaternion.Euler(hit.transform.localRotation.eulerAngles + new Vector3(0,90,0)));
            anim.SetTrigger("Shoot");
            return;
        }
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);

    }
}
