using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Falling : BaseState
{
    [SerializeField] private float airVelocity = 3.0f;
    [SerializeField] private float terminalVelocity = 24.0f;

    public override Vector3 ProcessMotion(Vector3 input)
    {
        input.x *= airVelocity;
        motor.verticalVelocity -= motor.gravity * Time.deltaTime;
        if (motor.verticalVelocity < -terminalVelocity)
            motor.verticalVelocity = -terminalVelocity;
        return input;
    }

    public override void Transition()
    {
        if (motor.isGrounded)
            motor.ChangeState(GetComponent<State_Walking>());
    }
}
