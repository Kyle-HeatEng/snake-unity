
using UnityEngine;
using UnityEngine.InputSystem;

public class GameState
{
    public Vector3 PlayerDirection;

    public GameState(Vector3 playerDirection)
    {
        PlayerDirection = playerDirection;
    }
}


public class GameManager : MonoBehaviour
{
    public GameObject SnakePrefab;

    public static int speed = 3;

    private GameState gameState;


    // Start is called before the first frame update
    void Start()
    {
        gameState = new(Vector3.forward * speed * Time.deltaTime);
        Controller.Movement += test;
        Instantiate(SnakePrefab);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EventBridge.Update(gameState);
    }

    void test(InputAction.CallbackContext movement)
    {
        Debug.Log(movement);        
    }

}
