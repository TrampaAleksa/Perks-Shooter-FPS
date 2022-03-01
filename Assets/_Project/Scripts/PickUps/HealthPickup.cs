using System;
using System.Collections;
using UnityEngine;

public class HealthPickup : MonoBehaviour, IPlayerPickUp
{
    public long healAmount;
    private Health playerHealth;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        //TODO - Urgently handle character collider logic
        playerHealth = other.GetComponent<CharacterCollider>()
            .controller.GetComponent<Health>();
            
        OnPickup();
    }
    
    public void OnPickup()
    {
        if (playerHealth.IsMax())
            return;
        
        playerHealth.AddHealth(healAmount);
        
        DestroyPickup();
    }
    private void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
