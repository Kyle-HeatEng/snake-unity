using System.Collections.Generic;
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
        EventBridge.OnGameUpdate += Move;
        EventBridge.OnUpdateSnakeHeadPosition += UpdateNodesDirection;
    }

    void OnDisable()
    {
        EventBridge.OnGameUpdate -= Move;
        EventBridge.OnUpdateSnakeHeadPosition -= UpdateNodesDirection;
    }


    public void Move(GameState currentState, GameState updatedState)
    {
        if (SnakeNodes == null) return;


        for (int i = 0; i < SnakeNodes.Count; i++)
        {
            GameObject snakeNodeGameObject = SnakeNodes[i];
            bool isHead = i == 0;
            SnakeNode snakeNode = snakeNodeGameObject.GetComponent<SnakeNode>();
            
            UpdateNodesPosition(snakeNode, isHead && !CompareVector3.Compare(updatedState.SnakeHeadDirection, snakeNode.NodeDirection));
            
            //If the current node instance is the head and the direction has changed
            if (isHead && !CompareVector3.Compare(updatedState.SnakeHeadDirection, snakeNode.NodeDirection))
            {
                var currentNodeDirection = snakeNode.NodeDirection;
                snakeNode.NodeDirection = updatedState.SnakeHeadDirection;

                Logger.Log("There was a change in direction", LogLocation.Snake, "yellow");
                Logger.Log("CurrentNodeDirection: " + currentNodeDirection, LogLocation.Snake);
                Logger.Log("UpdatedState.SnakeHeadDirection: " + updatedState.SnakeHeadDirection, LogLocation.Snake);
                continue;
            }

            Vector3 snakeNodeCurrentDirection = snakeNode.NodeDirection;
            Vector3 prevSnakeNodeDirection = isHead ?  SnakeNodes[i].GetComponent<SnakeNode>().NodeDirection : SnakeNodes[i - 1].GetComponent<SnakeNode>().NodeDirection;
            Logger.Log("Movement", LogLocation.Snake, "yellow");
            Logger.Log("PrevSnakeNodeDirection: " + prevSnakeNodeDirection, LogLocation.Snake);
            Logger.Log("SnakeNodeCurrentDirection: " + snakeNodeCurrentDirection, LogLocation.Snake);


            snakeNode.NodeDirection = prevSnakeNodeDirection;

        }
    }

    private void UpdateNodesPosition(SnakeNode snakeNode, bool isHeadWithUpdatedDirection = false)
    {
        if(isHeadWithUpdatedDirection)
        {
            //TODO: need to remove the current direction and place in a different location
            /**
            *
            * |   |   |   |    |   |   |   |
            * |   | f | s |    |   | s |   |
            * |   |   |   |    |   | f |   |
            * |   |   |   |    |   |   |   |
            *
            * f = first;
            * s = second;
            *
            */ 
            Logger.Log("Head with updated direction", LogLocation.Snake, "yellow");
            
            Vector3 headNodeCurrentPosition = snakeNode.transform.position;
            
            Vector3 headNodeUpdatedPosition = headNodeCurrentPosition + snakeNode.NodeDirection;
            
            snakeNode.transform.position = headNodeUpdatedPosition;
            
            return;
        }

        Vector3 snakeNodeCurrentPosition = snakeNode.transform.position;
        
        Vector3 snakeNodeUpdatedPosition = snakeNodeCurrentPosition + snakeNode.NodeDirection;

        Logger.Log("Updating Node Position", LogLocation.Snake, "yellow");
        Logger.Log("SnakeNodeUpdatedPosition: " + snakeNodeUpdatedPosition, LogLocation.Snake);
        Logger.Log("SnakeNodeCurrentPosition: " + snakeNodeCurrentPosition, LogLocation.Snake);
        Logger.Log("SnakeNodeDirection: " + snakeNode.NodeDirection, LogLocation.Snake);

        snakeNode.transform.position = snakeNodeUpdatedPosition;
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

    private void UpdateNodesDirection(Vector3 newHeadDirection)
    {

        for (int i = SnakeNodes.Count - 1; i >= 0; i--)
        {
            bool isHead = i == 0;
            if (isHead)
            {
                SnakeNode headNode = SnakeNodes[i].GetComponent<SnakeNode>();

                headNode.NodeDirection = newHeadDirection;
                
                continue;
            }

            SnakeNode snakeNode = SnakeNodes[i].GetComponent<SnakeNode>();

            snakeNode.NodeDirection = SnakeNodes[i - 1].GetComponent<SnakeNode>().NodeDirection;
            
        }

    }
}
