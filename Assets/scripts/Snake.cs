using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject SnakeNode;
    public int SnakeLength = 1;

    private List<GameObject> SnakeNodes;
    // Start is called before the first frame update
    void Start()
    {
        SnakeNodes = CreateSnakeNodes(SnakeLength);
    }

    void OnEnable() 
    {
      GameManager.OnMoveSnake += Move;
    }

    void OnDisable()
    {
        GameManager.OnMoveSnake -= Move;
    }


    public void Move(Vector3 direction)
    {
        foreach(var snakeNode in SnakeNodes)
        {
            snakeNode.transform.position += direction;
        }
    }

    private List<GameObject> CreateSnakeNodes(int length) 
    {
        var snakeNodes = new List<GameObject>();

        for (int i = 0; i < length; i++)
        {
            var node = Instantiate(SnakeNode, new Vector3(i, 0, 0), Quaternion.identity);
            
            snakeNodes.Add(node);
        }
        return snakeNodes;
    }
}
