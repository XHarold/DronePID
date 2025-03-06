using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DroneMovementScript : MonoBehaviour
{
    Rigidbody ourDrone;

    private void Awake()
    {
        ourDrone = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();//水平旋转 左右转向
        ClampingSpeedValues();//限制速度
        Swerve();//左右横向滑动

        ourDrone.AddRelativeForce(Vector3.up * upforce);
        ourDrone.rotation = Quaternion.Euler(
            new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways)
        );
    }
    public float upforce;
    void MovementUpDown()
    {
        if (Input.GetKey(KeyCode.I))
        {
            upforce = 450;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            upforce = -200;
        }
        else
        {
            upforce = 98.1F;
        }
    }
    private float movementForwardSpeed = 500.0f;
    private float tiltAmountForward = 0f;
    private float tiltVelocityForward;
    void MovementForward()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            ourDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);
        }
    }

    private float wantedYRotation;
    private float currentYRotation;
    private float rotateAmountByKeys = 2.5f;
    private float rotationYVelocity;
    void Rotation()
    {
        if (Input.GetKey(KeyCode.J))
        {
            wantedYRotation -= rotateAmountByKeys;
        }
        if (Input.GetKey(KeyCode.L))
        {
            wantedYRotation += rotateAmountByKeys;
        }
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }

    private Vector3 velocityToSmoothDampToZero;
    void ClampingSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }
    }
    private float sideMovementAmount = 300.0f;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;
    void Swerve()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountSideways, -20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);

        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }
}
