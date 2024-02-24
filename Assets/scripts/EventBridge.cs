using System;
using UnityEngine;
using UnityEngine.InputSystem;

public static class EventBridge
{

    public static event Action<GameState> OnMoveSnake;
    public static event Action<Vector3> OnUpdateSnakeHeadPosition;

    public static void Update(GameState gameState) 
    {
      OnMoveSnake?.Invoke(gameState);
    } 

    public static void UpdateSnakeHeadPosition(Vector3 SnakeHeadDirection)
    {
      OnUpdateSnakeHeadPosition?.Invoke(SnakeHeadDirection);
    }


}
