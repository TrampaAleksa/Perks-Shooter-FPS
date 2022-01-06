using System;
using UnityEngine;

public class LiftCollider : MonoBehaviour
{
    [SerializeField]
    private LiftColliderType type;

    private TimedAction _timedAction;
    private Lift _lift;

    private void Awake()
    {
        _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Lift"))
            return;

        Debug.Log("Triggered With Lift: " + type);
        _lift = other.GetComponent<Lift>();

        if (type == LiftColliderType.Upper)
        {
            _lift.StopLift();
            _lift.direction = -1f;
            _timedAction.StartTimedAction(StartLoweringLift, _lift.delayBeforeLowering);
            return;
        }

        if (type == LiftColliderType.Lower)
        {
            _lift.StopLift();
            _lift.direction = 1f;
            return;
        }
    }

    private void StartLoweringLift()
        => _lift.StartLift();


    private enum LiftColliderType
    {
        Upper, 
        Lower
    }
}