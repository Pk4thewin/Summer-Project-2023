using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed;
    private float currentSpeed;
    public float speedSmoothTime = 0.1f;
    public float startSpeedSmoothTime = 0.05f;
    private float speedSmoothVelocity;
    public float turnSmoothTime = 0.1f; 
    private float turnSmoothVelocity;
    private Vector3 currentDirection = Vector3.zero;
    public float gravityValue = -9.81f;
    public bool isGrounded = true;
    public float jumpHeight = 2.0f;
    private float groundCheckDistance = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsPlayerGrounded();
        Vector3 targetDirection = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        if(targetDirection.magnitude >= 0.1f) // add a deadzone to ignore small inputs
        {
            float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            currentDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            float targetSpeed = playerSpeed * targetDirection.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, startSpeedSmoothTime);
        }
        else
        {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, 0, ref speedSmoothVelocity, speedSmoothTime);
        }

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        controller.Move(currentDirection * currentSpeed * Time.deltaTime);

    }
    bool IsPlayerGrounded() 
    {
        return Physics.Raycast(transform.position, -Vector3.up, controller.bounds.extents.y + groundCheckDistance);
    }
}
