using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Jumping : BaseState
{
    [SerializeField] private float airVelocity = 3.0f;
    [SerializeField] private float jumpVelocity = 7.0f;

    public override void Construct()
    {
        motor.verticalVelocity = jumpVelocity;
    }

    public override Vector3 ProcessMotion(Vector3 input)
    {
        input.x *= airVelocity;
        motor.verticalVelocity -= motor.gravity * Time.deltaTime;

        return input;
    }

    public override void Transition()
    {
        if (motor.verticalVelocity < 0)
            motor.ChangeState(GetComponent<State_Falling>());
    }
}
