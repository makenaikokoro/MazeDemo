using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Maze mazePrefab;
    private Maze mazeInstance;

    void Start()
    {
        MazeInit();
    }

    void MazeInit()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Init();
    }
}
