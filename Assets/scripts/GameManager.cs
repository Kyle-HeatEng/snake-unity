
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

    public static float Speed = 0.1f;

    public static GameManager Instance;

    public GameState GameState {get { return _GameState; }}
    private GameState _GameState;

    GameManager()
    {
       if(Instance == null)
       {
          Instance = this;
       }
    }


    // Start is called before the first frame update
    void Start()
    {
        _GameState = new(Vector3.forward * Speed * Time.deltaTime);
        Instantiate(SnakePrefab);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EventBridge.Update(_GameState);
    }

    void OnEnable()
    {
        EventBridge.OnUpdateSnakeHeadPosition += UpdateSnakeHeadPosition;
    }

    void OnDisable()
    {
        EventBridge.OnUpdateSnakeHeadPosition -= UpdateSnakeHeadPosition;
    }

    void UpdateSnakeHeadPosition(Vector3 SnakeHeadDirection)
    {
        _GameState.SnakeHeadDirection = SnakeHeadDirection * Speed;
        //Debug.Log(SnakeHeadDirection);
       // Debug.Log(_GameState.SnakeHeadDirection);
    }

}
