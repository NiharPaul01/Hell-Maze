using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    Vector2 look;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float movementspeed = 3f;
    [SerializeField] float sprintspeed = 8f;
    [SerializeField] float jumpspeed = 5f;
    [SerializeField] float mass = 1f;
    CharacterController controller;
    Vector3 velocity;
    private float variableSpeed=0f;
    


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGravity();
        UpdateMovement();
        UpdateLook();
    }

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1f : velocity.y + gravity.y;
    }

    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        variableSpeed = movementspeed;

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.forward * x;
        input = Vector3.ClampMagnitude(input, 1f);

        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y += jumpspeed;
        }
        if(Input.GetButton("Fire3"))
        {

            variableSpeed = sprintspeed;
        } 

        controller.Move((input * variableSpeed + velocity) * Time.deltaTime);

    }
    void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        look.y = Mathf.Clamp(look.y, -89f, 89f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }
}
