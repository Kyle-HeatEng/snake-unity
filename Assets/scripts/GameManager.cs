using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<Vector3> OnMoveSnake;
    public GameObject SnakePrefab;

    public int TickRate = 5;

    private GameObject Snake;


    // Start is called before the first frame update
    void Start()
    {
        Snake = Instantiate(SnakePrefab);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.frameCount % TickRate == 0) return;
        OnMoveSnake?.Invoke(new Vector3(1, 0, 0));
    }
}
