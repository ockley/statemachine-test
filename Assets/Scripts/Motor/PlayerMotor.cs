using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float gravity = 15.0f;

    private CharacterController controller;
    private BaseState currentState;
    private float verticalVelocity;

    private void Start()
    {
        controller.GetComponent<CharacterController>();
        currentState = GetComponent<State_Walk>();
    }

    void Update()
    {
        // Grab input
        Vector3 input = PoolInput();

        //Define our move delta
        Vector3 moveDelta = Vector3.zero;

        // Apply vertical velocity to move delta
        moveDelta.y = verticalVelocity;

        // TODO Ask our state to define our movement this frame


        // Move player
        controller.Move(moveDelta * Time.deltaTime);

    }
    public void ChangeState(BaseState state)
    {

    }

    // This is just to read input from keyboard
    private Vector3 PoolInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector3(x, y);
    }

}
