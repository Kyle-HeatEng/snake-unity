
using UnityEngine;
using UnityEngine.InputSystem;

public class GameState
{
    public Vector3 SnakeHeadDirection;

    public GameState(Vector3 _SnakeHeadDirection)
    {
        SnakeHeadDirection = _SnakeHeadDirection;
    }
}


public class GameManager : MonoBehaviour
{
    public GameObject SnakePrefab;

    public static GameManager Instance;

    public GameState GameState {get { return _gameState; }}
    private GameState _gameState;

    private GameState _previousGameState;

    // Define a field to keep track of the elapsed time
    private float elapsedTime = 0f;
    // Define your desired update interval in seconds (e.g., 60 seconds)
    private float updateInterval = 0.3f;

    private GameManager()
    {
       if(Instance == null)
       {
          Instance = this;
       }
    }


    // Start is called before the first frame update
    private void Start()
    {
        _gameState = new(Vector3.forward);
        _previousGameState = _gameState;
        Instantiate(SnakePrefab);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Increment the elapsed time by the time since the last frame
        elapsedTime += Time.fixedDeltaTime;

        // Check if the elapsed time has exceeded the update interval
        if (elapsedTime >= updateInterval)
        {
            // Reset the elapsed time
            elapsedTime = 0f;

            // Call your update method
            EventBridge.Update(_previousGameState, _gameState);
        }
    }

    private void OnEnable()
    {
        EventBridge.OnUpdateSnakeHeadPosition += UpdateSnakeHeadPosition;
    }

    private void OnDisable()
    {
        EventBridge.OnUpdateSnakeHeadPosition -= UpdateSnakeHeadPosition;
    }

    private void UpdateSnakeHeadPosition(Vector3 SnakeHeadDirection)
    {
        _previousGameState = _gameState;
        _gameState.SnakeHeadDirection = SnakeHeadDirection;
    }

}
