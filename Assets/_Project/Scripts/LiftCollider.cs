using UnityEngine;

public class LiftCollider : MonoBehaviour
{
    [SerializeField]
    private LiftColliderType type;
    
    
    
    
    
    
    private enum LiftColliderType
    {
        Upper, 
        Lower
    }
}