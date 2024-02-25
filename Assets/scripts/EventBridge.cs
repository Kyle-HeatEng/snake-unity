using System;
using UnityEngine;
using UnityEngine.InputSystem;

public static class EventBridge
{

    public static event Action<GameState, GameState> OnGameUpdate;
    public static event Action<Vector3> OnUpdateSnakeHeadPosition;

    public static void Update(GameState currentState, GameState updatedState)
    {
      OnGameUpdate?.Invoke(currentState, updatedState);
    }

    public static void UpdateSnakeHeadPosition(Vector3 SnakeHeadDirection)
    {
      OnUpdateSnakeHeadPosition?.Invoke(SnakeHeadDirection);
    }


}
