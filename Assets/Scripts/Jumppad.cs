using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var motor = other.GetComponent<PlayerMotor>();
        if(motor != null)
        {
            motor.ChangeState(motor.GetComponent<State_Jumppad>());
        }
    }
}
