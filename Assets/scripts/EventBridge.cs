using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class EventBridge
{

    public static event Action<GameState> OnMoveSnake;

    public static void Update(GameState gameState) 
    {
      OnMoveSnake?.Invoke(gameState);
    } 

}
