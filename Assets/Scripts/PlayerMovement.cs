using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 7.0f;
    [SerializeField] private float gravity = 15.0f;
    [SerializeField] private float speed = 5.0f;

    private CharacterController controller;
    private float verticalVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Grab input
        Vector3 input = PoolInput();

        //Define our move delta
        Vector3 moveDelta = Vector3.zero;
        moveDelta.x = input.x * speed;

        if(controller.isGrounded)
        {
            verticalVelocity = -gravity;

            if (Input.GetKeyDown(KeyCode.Space))
                verticalVelocity = jumpForce;
        } else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveDelta.y = verticalVelocity;

        // Move player
        controller.Move(moveDelta * Time.deltaTime);
    }

    // This is just to read input from keyboard
    private Vector3 PoolInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector3(x, y);
    }
}
