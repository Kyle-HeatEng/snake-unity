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

    // <summary>
    // This method is called when the player moves the snake
    // Using Unity's Input System, we can read the value of the input and 
    // pass it to the UpdateSnakeHeadPosition method in the EventBridge static class.
    // - The Input is read as a Vector2 and then converted to a Vector3
    // - The Input System Custom Input class is used to define how the input is read
    // <param name="context"></param>
    // </summary>
    private void OnMoveSnake(InputAction.CallbackContext context) 
    {
        
        Vector2 MoveInput = context.ReadValue<Vector2>();

        Vector3 UpdatedSnakeHeadDirection = new Vector3(MoveInput.x, 0, MoveInput.y); 


        EventBridge.UpdateSnakeHeadPosition(UpdatedSnakeHeadDirection);
    }
}
