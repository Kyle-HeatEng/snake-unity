using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snakeNodeGameObject;
    private List<GameObject> snakeNodeGameObjects;

    public List<SnakeNode> snakeNodes;
    public int SnakeLength = 1;
    // Start is called before the first frame update
    void Start()
    {
        snakeNodeGameObjects = CreateSnakeNodes(SnakeLength);
        snakeNodes = snakeNodeGameObjects.ConvertAll(snakeNodeGameObject => snakeNodeGameObject.GetComponent<SnakeNode>());
    }

    private List<GameObject> CreateSnakeNodes(int length)
    {
        var snakeNodes = new List<GameObject>();

        for (int i = 0; i < length; i++)
        {
            var node = Instantiate(snakeNodeGameObject, new Vector3(i, 0, 0), Quaternion.identity);

            snakeNodes.Add(node);
        }

        return snakeNodes;
    }

    void OnEnable()
    {
        EventBridge.OnGameUpdate += Move;    
    }

    void OnDisable()
    {
        EventBridge.OnGameUpdate -= Move;
    }

    public void Move(GameState currentState, GameState updatedState)
    {
        if (snakeNodeGameObjects == null) return;


        for (int i = snakeNodeGameObjects.Count - 1; i >= 0; i--)
        {
            bool isHead = i == 0;

            SnakeNode snakeNode = snakeNodes[i];
            SnakeNode parentNode = isHead ? null : snakeNodes[i - 1];
            
            UpdateNodesPosition(snakeNode, parentNode, isHead, updatedState);
            
            UpdateSnakeNodeDirection(snakeNode, parentNode, isHead, updatedState);
        }
    }

    private void UpdateNodesPosition(SnakeNode snakeNode, SnakeNode parentNode, bool isHead, GameState updatedState)
    {
        if(isHead)
        {   
            Vector3 headNodeCurrentPosition = snakeNode.transform.position;
            
            Vector3 headNodeUpdatedPosition = headNodeCurrentPosition + updatedState.SnakeHeadDirection;
            
            snakeNode.transform.position = headNodeUpdatedPosition;
            
            return;
        }

        snakeNode.transform.position = parentNode.transform.position;
    }

    private void UpdateSnakeNodeDirection(SnakeNode snakeNode, SnakeNode parentNode, bool isHead, GameState updatedState)
    {
        if(isHead)
        {
            snakeNode.NodeDirection = updatedState.SnakeHeadDirection;
            return;
        }

        snakeNode.NodeDirection = parentNode.NodeDirection;
    }

    

}
