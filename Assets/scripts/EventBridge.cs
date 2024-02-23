using System;
using UnityEngine.InputSystem;

public static class EventBridge
{

    public static event Action<GameState> OnMoveSnake;

    public static void Update(GameState gameState) 
    {
      OnMoveSnake?.Invoke(gameState);
    } 

}
