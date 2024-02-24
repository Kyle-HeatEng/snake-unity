using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public static CustomInput Input;
    
    public static event Action<InputAction.CallbackContext> Movement 
    {
        add { Input.Player.Movement.performed += value; }
        remove { Input.Player.Movement.performed -= value; }
    }
    
    private void Awake()
    {
        Input = new CustomInput();

    }

    private void OnEnable()
    {
        Input.Enable();
        Movement += OnMoveSnake;
    }

    private void OnDisable()
    {
        Input.Disable();
        Movement -= OnMoveSnake;
    }

    private void OnMoveSnake(InputAction.CallbackContext context) 
    {
        Vector2 MoveInput = context.ReadValue<Vector2>();

        Vector3 UpdatedSnakeHeadDirection = new Vector3(-(int)MoveInput.x, 0, (int)MoveInput.y); //TODO this is hacky 


        EventBridge.UpdateSnakeHeadPosition(UpdatedSnakeHeadDirection);
    }
}
