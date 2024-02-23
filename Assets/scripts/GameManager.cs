using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Snake;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Snake);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
