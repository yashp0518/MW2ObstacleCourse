using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //checking whether or not we are on the ground
        isGrounded = controller.isGrounded;

    }

    //recieve inputs for inputManager and apply to character
    public void ProcessMove(Vector2 input)
    {
        //initialize player direction as a 3D vector
        Vector3 moveDirection = Vector3.zero;

        //transfer inputs in x and y plane
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        //controller moves based on our move direction coupled with speed and time
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        //we want our y direction to be influenced by gravity
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -5f;
        }
        controller.Move(playerVelocity * Time.deltaTime);

    }
    //handling our player jumping
    public void Jump() {
        //player must be on ground before we can jump
        if (isGrounded) {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
            }
}