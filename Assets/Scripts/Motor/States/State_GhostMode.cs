using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_GhostMode : BaseState
{
    [SerializeField] private float flySpeed = 15.0f;

    public override Vector3 ProcessMotion(Vector3 input)
    {
        input.x *= flySpeed;
        motor.verticalVelocity = input.y * flySpeed;
        return input;
    }

    public override void Transition()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            motor.ChangeState(GetComponent<State_Walking>());
    }
}
