using UnityEngine;

public class BaseState : MonoBehaviour
{
    protected PlayerMotor motor;


    private void Awake()
    {
        motor = GetComponent<PlayerMotor>();
    }

    public virtual void Construct()
    {

    }

    public virtual void Destruct()
    {

    }

    public virtual void Transition()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            motor.ChangeState(GetComponent<State_GhostMode>());
    }

    public virtual Vector3 ProcessMotion(Vector3 input)
    {
        return input;
    }
}
