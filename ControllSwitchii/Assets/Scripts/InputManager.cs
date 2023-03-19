using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerController.Instance.nextDirection = context.ReadValue<Vector2>();
            
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            PlayerController.Instance.isJumping = true;
            
        }
        if(context.canceled)
        {
            PlayerController.Instance.isJumping = false;
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            PlayerController.Instance.isShooting = true;
        }
        if(context.canceled)
        {
            PlayerController.Instance.isShooting = false;
        }
    }
    public void OnStateChange(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            PlayerController.Instance.isButtonChange = true;
        }
        
    }
}
