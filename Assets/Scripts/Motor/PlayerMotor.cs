using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float gravity = 15.0f;
    public float verticalVelocity;
    public bool isGrounded;

    private CharacterController controller;
    private BaseState currentState;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentState = GetComponent<State_Walking>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        // Grab input
        Vector3 input = PoolInput();

        //Define our move delta
        Vector3 moveDelta = Vector3.zero;

        // TODO Ask our state to define our movement this frame
        moveDelta = currentState.ProcessMotion(input);
        
        // Apply vertical velocity to move delta
        moveDelta.y = verticalVelocity;

        // Move player
        controller.Move(moveDelta * Time.deltaTime);

        // Check if we have to change state
        currentState.Transition();
    }
    public void ChangeState(BaseState state)
    {
        currentState.Destruct();
        currentState = state;
        currentState.Construct();
    }

    // This is just to read input from keyboard
    private Vector3 PoolInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector3(x, y);
    }

}
