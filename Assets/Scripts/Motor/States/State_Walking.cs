using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Walking : BaseState
{
    [SerializeField] private float runSpeed = 10.0f;

    public override void Construct()
    {
        base.Construct();
    }

    public override Vector3 ProcessMotion(Vector3 input)
    {
        //print("ProcessMotion i State_Walking");
        input.x *= runSpeed;
        motor.verticalVelocity = -1;
        return input;
    }

    public override void Transition()
    {
        base.Transition();

        if (!motor.isGrounded)
            motor.ChangeState(GetComponent<State_Falling>());

        if (Input.GetKeyDown(KeyCode.Space))
            motor.ChangeState(GetComponent<State_Jumping>());

    }

    public override void Destruct()
    {
        base.Destruct();
    }
}
