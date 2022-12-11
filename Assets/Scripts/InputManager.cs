using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        //links our jump function to our jump action
        //uses callback, since we want to check for when jump is performed
        onFoot.Jump.performed += ctx => motor.Jump();
        
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        //tell the player to move using the value from movement actiom
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.processLook(onFoot.Look.ReadValue<Vector2>());
    }
    //controls when to turn on functionality for when we're walking
    private void OnEnable()
    {
        onFoot.Enable();
    }
    //turns off walking functionality
    private void OnDisable()
    {
        onFoot.Disable();
    }
    
    
}
